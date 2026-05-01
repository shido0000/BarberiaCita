using API.Application.Mapper.Nomencladores;
using API.Application.Mapper.Seguridad;
using API.Application.Mapper.Multibarbero;
using AutoMapper;

namespace API.Application.Mapper
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMappers(this IServiceCollection services, MapperConfigurationExpression cfg)
        {
            IMapper mapper = new MapperConfiguration(cfg).CreateMapper();
            services.AddSingleton(mapper);
        }
        public static MapperConfigurationExpression AddAutoMapperLeadOportunidade(this MapperConfigurationExpression cfg)
        {
            cfg.AddProfile<UsuarioDtoProfile>();
            cfg.AddProfile<RolDtoProfile>();
            cfg.AddProfile<PermisoDtoProfile>();

            cfg.AddProfile<CategoriaDtoProfile>();
            cfg.AddProfile<OrigenDtoProfile>();
            cfg.AddProfile<GrupoDtoProfile>();
            cfg.AddProfile<FamiliaDtoProfile>();

            // Perfiles Multibarbero
            cfg.AddProfile<MultibarberoDtoProfile>();

            return cfg;
        }
        public static MapperConfigurationExpression CreateExpression()
        {
            return new MapperConfigurationExpression();
        }
    }
}
