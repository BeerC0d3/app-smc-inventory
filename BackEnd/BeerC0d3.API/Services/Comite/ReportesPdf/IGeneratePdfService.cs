using BeerC0d3.API.Dtos.Comite.Personas;
using BeerC0d3.API.Dtos.Comite.Reportes;
using QuestPDF.Fluent;
using System.Threading.Tasks;

namespace BeerC0d3.API.Services.Comite.ReportesPdf
{
   
    public interface IGeneratePdfService
    {
        Document  ReporteCooperacionIntegrante(RptTotalCooperacionDto resultMapper,ICollection<PersonaCooperacionDto> listPersonaCooperacion);
    }
}
