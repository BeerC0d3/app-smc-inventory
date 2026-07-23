namespace BeerC0d3.API.Dtos.Comite.Personas
{
    public class PersonaDto
    {
       
        public int seccionId { set; get; }
		public string Seccion { get; set; }
		public int personaId { get; set; }
		public string Nombre { get; set; }
		public string Calle { get; set; }
		public string Colonia { get; set; }
		public string Numero { get; set; }
		public string Latitud { get; set; }
		public string Longitud { get; set; }
		
    }
}
