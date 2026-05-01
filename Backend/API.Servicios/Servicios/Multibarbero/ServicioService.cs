using AutoMapper;
using API.Data.IUnitOfWorks;
using API.Domain.Interfaces.Servicios.Multibarbero;
using API.Application.Dtos.Multibarbero.Servicio;
using API.Application.Dtos.Comunes;
using API.Data.Entidades.Multibarbero;

namespace API.Servicios.Servicios.Multibarbero
{
    public class ServicioService : IServicioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServicioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServicioDto> ObtenerPorId(Guid id)
        {
            var entidad = await _unitOfWork.Servicios.ObtenerPorId(id);
            if (entidad == null) throw new KeyNotFoundException($"Servicio con ID {id} no encontrado");
            return _mapper.Map<ServicioDto>(entidad);
        }

        public async Task<ListadoPaginadoDto<ServicioDto>> ObtenerListadoPaginado(FiltrarConfigurarListadoPaginadoServicioInputDto filtro)
        {
            var entidades = await _unitOfWork.Servicios.ObtenerListadoPaginado(filtro);
            return _mapper.Map<ListadoPaginadoDto<ServicioDto>>(entidades);
        }

        public async Task<ServicioDto> Crear(CrearServicioInputDto dto)
        {
            var entidad = _mapper.Map<Servicio>(dto);
            await _unitOfWork.Servicios.Crear(entidad);
            await _unitOfWork.GuardarCambios();
            return _mapper.Map<ServicioDto>(entidad);
        }

        public async Task<ServicioDto> Actualizar(ActualizarServicioInputDto dto)
        {
            var entidad = await _unitOfWork.Servicios.ObtenerPorId(dto.Id);
            if (entidad == null) throw new KeyNotFoundException($"Servicio con ID {dto.Id} no encontrado");
            
            _mapper.Map(dto, entidad);
            _unitOfWork.Servicios.Actualizar(entidad);
            await _unitOfWork.GuardarCambios();
            return _mapper.Map<ServicioDto>(entidad);
        }

        public async Task Eliminar(Guid id)
        {
            var entidad = await _unitOfWork.Servicios.ObtenerPorId(id);
            if (entidad == null) throw new KeyNotFoundException($"Servicio con ID {id} no encontrado");
            _unitOfWork.Servicios.Eliminar(entidad);
            await _unitOfWork.GuardarCambios();
        }
    }
}
