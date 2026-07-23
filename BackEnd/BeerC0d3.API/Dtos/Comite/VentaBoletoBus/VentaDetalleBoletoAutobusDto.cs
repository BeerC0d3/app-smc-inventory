namespace BeerC0d3.API.Dtos.Comite.VentaBoletoBus
{
    public class VentaDetalleBoletoAutobusDto
    {
        public int Id { get; set; }
        public int VentaBoletoAutId { get; set; }
        public int BoletoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
