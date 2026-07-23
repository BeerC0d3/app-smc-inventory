using BeerC0d3.API.Dtos.Comite.Periodos;

namespace BeerC0d3.API.Services.Comite.Periodos
{
    public interface IPeriodoService
    {
        Task<string> AddUpdatePeriodo(PeriodoAddUpdateDto periodoDto);
        Task<string> AddWithUsersPeriodo();
    }
}
