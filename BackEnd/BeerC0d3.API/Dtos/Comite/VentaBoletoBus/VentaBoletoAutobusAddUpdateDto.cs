namespace BeerC0d3.API.Dtos.Comite.VentaBoletoBus
{
    public class VentaBoletoAutobusAddUpdateDto
    {
        public VentaBoletoAutobusDto VentaBoleto { get; set; }
        public VentaMontoBoletoAutobusDto VentaMontoBoleto { get; set; }
        public ICollection<VentaDetalleBoletoAutobusDto> VentaDetalleBoleto { get; set; }
    }
}
