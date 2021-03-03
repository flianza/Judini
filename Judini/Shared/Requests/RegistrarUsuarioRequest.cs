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

        [Required]
        public string Nombre { get; set; }
        
        [Required]
        public string Apellido { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
