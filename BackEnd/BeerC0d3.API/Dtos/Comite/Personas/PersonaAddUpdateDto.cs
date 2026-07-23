namespace BeerC0d3.API.Dtos.Comite.Personas
{
    public class PersonaAddUpdateDto
    {
        public int Id { get; set; }
        public int seccionId { get; set; }
        public string Nombre { get; set; }
        public string Colonia { get; set; }
        public string Callle { get; set; }
        public string Numero { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
