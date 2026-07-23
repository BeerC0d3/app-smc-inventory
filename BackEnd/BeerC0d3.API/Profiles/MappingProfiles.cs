using AutoMapper;
using BeerC0d3.API.Dtos.Comite.Personas;
using BeerC0d3.API.Dtos.Comite.Reportes;
using BeerC0d3.API.Dtos.Comite.Seccion;
using BeerC0d3.API.Dtos.Comite.VentaBoletoBus;
using BeerC0d3.API.Dtos.Seguridad;
using BeerC0d3.API.Dtos.Sistema;
using BeerC0d3.Core.Entities.Comite;
using BeerC0d3.Core.Entities.Seguridad;
using BeerC0d3.Core.Entities.Sistema;

namespace BeerC0d3.API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Menu, MenuDto>()
              .ReverseMap();

            CreateMap<CatalogoDetalle, ResultCatDetalleDto>()
           .ReverseMap()
           .ForMember(origen => origen.Catalogo, dest => dest.Ignore());

            CreateMap<Rol, RolDto>()
             .ReverseMap();

            CreateMap<Catalogo, CatalogoDto>()
            .ReverseMap();

            CreateMap<Seccion, SeccionDto>()
            .ReverseMap();

            CreateMap<Persona, PersonaDto>()
            .ReverseMap();

            CreateMap<Persona, TotalCooperacionDto>()
            .ReverseMap();

            CreateMap<BoletoAutobus, BoletoAutobusDto>()
           .ReverseMap();

            CreateMap<VentaBoletoAutobus, VentaBoletoAutobusResumenDto>()
          .ReverseMap();

            CreateMap<Persona, RptTotalCooperacionDto>()
         .ReverseMap();

            CreateMap<Cooperacion, PersonaCooperacionDto>()
     .ReverseMap();

        }
    }
}
