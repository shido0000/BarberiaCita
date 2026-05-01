using AutoMapper;
using API.Data.IUnitOfWorks;
using API.Domain.Interfaces.Servicios.Multibarbero;
using API.Application.Dtos.Multibarbero.Notificacion;
using API.Application.Dtos.Comunes;
using API.Data.Entidades.Multibarbero;

namespace API.Servicios.Servicios.Multibarbero
{
    public class NotificacionService : INotificacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificacionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<NotificacionDto> ObtenerPorId(Guid id)
        {
            var entidad = await _unitOfWork.Notificaciones.ObtenerPorId(id);
            if (entidad == null) throw new KeyNotFoundException($"Notificación con ID {id} no encontrada");
            return _mapper.Map<NotificacionDto>(entidad);
        }

        public async Task<ListadoPaginadoDto<NotificacionDto>> ObtenerListadoPaginado(FiltrarConfigurarListadoPaginadoNotificacionInputDto filtro)
        {
            var entidades = await _unitOfWork.Notificaciones.ObtenerListadoPaginado(filtro);
            return _mapper.Map<ListadoPaginadoDto<NotificacionDto>>(entidades);
        }

        public async Task<NotificacionDto> Crear(CrearNotificacionInputDto dto)
        {
            var entidad = _mapper.Map<Notificacion>(dto);
            await _unitOfWork.Notificaciones.Crear(entidad);
            await _unitOfWork.GuardarCambios();
            return _mapper.Map<NotificacionDto>(entidad);
        }

        public async Task<NotificacionDto> Actualizar(ActualizarNotificacionInputDto dto)
        {
            var entidad = await _unitOfWork.Notificaciones.ObtenerPorId(dto.Id);
            if (entidad == null) throw new KeyNotFoundException($"Notificación con ID {dto.Id} no encontrada");
            
            _mapper.Map(dto, entidad);
            _unitOfWork.Notificaciones.Actualizar(entidad);
            await _unitOfWork.GuardarCambios();
            return _mapper.Map<NotificacionDto>(entidad);
        }

        public async Task Eliminar(Guid id)
        {
            var entidad = await _unitOfWork.Notificaciones.ObtenerPorId(id);
            if (entidad == null) throw new KeyNotFoundException($"Notificación con ID {id} no encontrada");
            _unitOfWork.Notificaciones.Eliminar(entidad);
            await _unitOfWork.GuardarCambios();
        }
    }
}
