namespace BeerC0d3.API.Dtos.Comite.Periodos
{
    public class PeriodoAddUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EstatusId { get; set; }
        public decimal Monto { get; set; }
        public string IntegrantesId { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
