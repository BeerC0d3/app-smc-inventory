using BeerC0d3.API.Dtos.Comite.Periodos;
using BeerC0d3.API.Dtos.Comite.Seccion;

namespace BeerC0d3.API.Services.Comite.Secciones
{
    public interface ISeccionService
    {
        Task<string> AddUpdate(SeccionAddUpdateDto secctionDto,int userId);
        Task<ICollection<SeccionDto>> GetActives();
    }
}
