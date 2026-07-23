using System.ComponentModel.DataAnnotations;

namespace BeerC0d3.API.Dtos.Seguridad
{
    public class UsuarioDto
    {
        public int  Id { get; set; }
        public string NombreFull { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FotoUrl { get; set; }
        public string Roles { get; set; }
    }
}
