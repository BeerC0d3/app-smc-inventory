namespace BeerC0d3.API.Dtos.Sistema
{
    public class DatosCatDetalleDto
    {
        public int totalPages { get; set; }
        public ICollection<ResultCatDetalleDto> Result { get; set; }
    }


    public class ResultCatDetalleDto
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
