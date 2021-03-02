using System.ComponentModel.DataAnnotations;

namespace Judini.Shared.Requests
{
    public class IniciarSesionRequest
    {
        [Required]
        public string NombreDeUsuario { get; set; }
        
        [Required]
        public string Contrasenia { get; set; }
        
        public bool Recordarme { get; set; }
    }
}
