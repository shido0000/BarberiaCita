using API.Data.Entidades.Multibarbero;
using API.Data.IUnitOfWorks.Interfaces;
using API.Domain.Interfaces.Servicios.Multibarbero;
using API.Application.Dtos.Multibarbero.RolMultibarbero;
using API.Application.Dtos.Comunes;
using AutoMapper;
using FluentValidation;

namespace API.Servicios.Servicios.Multibarbero
{
    public class RolMultibarberoService : IRolMultibarberoService
    {
        private readonly IUnitOfWork<RolMultibarbero> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CrearRolMultibarberoInputDto> _validator;

        public RolMultibarberoService(
            IUnitOfWork<RolMultibarbero> unitOfWork,
            IMapper mapper,
            IValidator<CrearRolMultibarberoInputDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ListadoPaginadoDto<RolMultibarberoDto>> ObtenerListadoPaginado(FiltrarConfigurarListadoPaginadoRolMultibarberoInputDto filtro)
        {
            var query = _unitOfWork.Repository.ObtenerTodos();

            if (!string.IsNullOrWhiteSpace(filtro.Nombre))
                query = query.Where(x => x.Nombre.Contains(filtro.Nombre));

            if (filtro.Activo.HasValue)
                query = query.Where(x => x.Activo == filtro.Activo.Value);

            var listadoPaginado = await _unitOfWork.ObtenerListadoPaginado(query, filtro);
            return _mapper.Map<ListadoPaginadoDto<RolMultibarberoDto>>(listadoPaginado);
        }

        public async Task<RolMultibarberoDto> ObtenerPorId(Guid id)
        {
            var entidad = await _unitOfWork.Repository.ObtenerPorId(id);
            if (entidad == null)
                throw new KeyNotFoundException($"No se encontró el rol con ID {id}");

            return _mapper.Map<RolMultibarberoDto>(entidad);
        }

        public async Task<RolMultibarberoDto> Crear(CrearRolMultibarberoInputDto dto)
        {
            var validacion = await _validator.ValidateAsync(dto);
            if (!validacion.IsValid)
                throw new ValidationException(validacion.Errors);

            var entidad = _mapper.Map<RolMultibarbero>(dto);
            await _unitOfWork.Repository.Crear(entidad);
            await _unitOfWork.GuardarCambiosAsync();

            return _mapper.Map<RolMultibarberoDto>(entidad);
        }

        public async Task<RolMultibarberoDto> Actualizar(ActualizarRolMultibarberoInputDto dto)
        {
            var validacion = await _validator.ValidateAsync(dto);
            if (!validacion.IsValid)
                throw new ValidationException(validacion.Errors);

            var entidad = await _unitOfWork.Repository.ObtenerPorId(dto.Id);
            if (entidad == null)
                throw new KeyNotFoundException($"No se encontró el rol con ID {dto.Id}");

            _mapper.Map(dto, entidad);
            _unitOfWork.Repository.Actualizar(entidad);
            await _unitOfWork.GuardarCambiosAsync();

            return _mapper.Map<RolMultibarberoDto>(entidad);
        }

        public async Task Eliminar(Guid id)
        {
            var entidad = await _unitOfWork.Repository.ObtenerPorId(id);
            if (entidad == null)
                throw new KeyNotFoundException($"No se encontró el rol con ID {id}");

            _unitOfWork.Repository.Eliminar(entidad);
            await _unitOfWork.GuardarCambiosAsync();
        }
    }
}
