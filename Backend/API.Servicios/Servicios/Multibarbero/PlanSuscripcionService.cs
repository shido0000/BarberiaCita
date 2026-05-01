using AutoMapper;
using API.Data.IUnitOfWorks;
using API.Domain.Interfaces.Servicios.Multibarbero;
using API.Application.Dtos.Multibarbero.PlanSuscripcion;
using API.Application.Dtos.Comunes;
using API.Data.Entidades.Multibarbero;

namespace API.Servicios.Servicios.Multibarbero
{
    public class PlanSuscripcionService : IPlanSuscripcionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlanSuscripcionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DetallesPlanSuscripcionDto> ObtenerPorId(Guid id)
        {
            var entidad = await _unitOfWork.PlanesSuscripcion.ObtenerPorId(id);
            if (entidad == null) throw new KeyNotFoundException($"Plan de suscripción con ID {id} no encontrado");
            return _mapper.Map<DetallesPlanSuscripcionDto>(entidad);
        }

        public async Task<ListadoPaginadoDto<PlanSuscripcionDto>> ObtenerListadoPaginado(FiltrarConfigurarListadoPaginadoPlanSuscripcionInputDto filtro)
        {
            var entidades = await _unitOfWork.PlanesSuscripcion.ObtenerListadoPaginado(filtro);
            return _mapper.Map<ListadoPaginadoDto<PlanSuscripcionDto>>(entidades);
        }

        public async Task<PlanSuscripcionDto> Crear(CrearPlanSuscripcionInputDto dto)
        {
            var entidad = _mapper.Map<PlanSuscripcion>(dto);
            await _unitOfWork.PlanesSuscripcion.Crear(entidad);
            await _unitOfWork.GuardarCambios();
            return _mapper.Map<PlanSuscripcionDto>(entidad);
        }

        public async Task<PlanSuscripcionDto> Actualizar(ActualizarPlanSuscripcionInputDto dto)
        {
            var entidad = await _unitOfWork.PlanesSuscripcion.ObtenerPorId(dto.Id);
            if (entidad == null) throw new KeyNotFoundException($"Plan de suscripción con ID {dto.Id} no encontrado");
            
            _mapper.Map(dto, entidad);
            _unitOfWork.PlanesSuscripcion.Actualizar(entidad);
            await _unitOfWork.GuardarCambios();
            return _mapper.Map<PlanSuscripcionDto>(entidad);
        }

        public async Task Eliminar(Guid id)
        {
            var entidad = await _unitOfWork.PlanesSuscripcion.ObtenerPorId(id);
            if (entidad == null) throw new KeyNotFoundException($"Plan de suscripción con ID {id} no encontrado");
            _unitOfWork.PlanesSuscripcion.Eliminar(entidad);
            await _unitOfWork.GuardarCambios();
        }
    }
}
