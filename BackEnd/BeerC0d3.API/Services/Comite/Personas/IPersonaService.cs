using BeerC0d3.API.Dtos.Comite.Personas;
using BeerC0d3.API.Dtos.Comite.Seccion;

namespace BeerC0d3.API.Services.Comite.Personas
{
    public interface IPersonaService
    {
        Task<string> AddUpdate(PersonaAddUpdateDto model);
        Task<string> CooperacionPersona(CooperacionPersonaDto model);
    }
}
