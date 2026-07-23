namespace BeerC0d3.API.Dtos.Comite.Periodos
{
    public class PeriodosDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ClaveEstatus { get; set; }
        public string Estatus { get; set; }
        public string Ingresos { get; set; }
        public string Gastos { get; set; }
        public int Integrantes { get; set; }
    }
}
