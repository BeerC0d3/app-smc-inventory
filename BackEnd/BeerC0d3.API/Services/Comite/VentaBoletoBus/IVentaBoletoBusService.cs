using BeerC0d3.API.Dtos.Comite.VentaBoletoBus;

namespace BeerC0d3.API.Services.Comite.VentaBoletoBus
{
    public interface IVentaBoletoBusService
    {
        Task<string> AddUpdateVentaBoleto(VentaBoletoAutobusAddUpdateDto model);
    }
}
