using AutoMapper;
using API.Data.Entidades.Multibarbero;
using API.Application.Dtos.Multibarbero.PlanSuscripcion;

namespace API.Application.Mapper.Multibarbero
{
    public class PlanSuscripcionDtoProfile : BaseProfile
    {
        public PlanSuscripcionDtoProfile()
        {
            CreateMap<PlanSuscripcion, PlanSuscripcionDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ReverseMap();

            CreateMap<PlanSuscripcion, CrearPlanSuscripcionInputDto>()
                .ReverseMap();

            CreateMap<PlanSuscripcion, ActualizarPlanSuscripcionInputDto>()
                .ReverseMap();

            CreateMap<PlanSuscripcion, DetallesPlanSuscripcionDto>()
                .ForMember(d => d.CantidadSuscriptores, opt => opt.MapFrom(s => s.Suscripciones.Count));

            CreateMap<PlanSuscripcion, ListadoPaginadoPlanSuscripcionDto>()
                .AsBase<ListadoPaginadoDto<PlanSuscripcionDto>>();
        }
    }
}
