using System.ComponentModel.DataAnnotations;

namespace Judini.Shared.Requests
{
    public class RegistrarUsuarioRequest
    {
        [Required]
        public string NombreDeUsuario { get; set; }

        [Required]
        public string Contrasenia { get; set; }

        [Required]
        [Compare(nameof(Contrasenia), ErrorMessage = "Las contraseñas no coinciden")]
        public string ContraseniaRepetida { get; set; }
    }
}
