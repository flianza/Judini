using System.ComponentModel.DataAnnotations;

namespace Judini.Shared.Clientes
{
    public class CrearClienteRequest
    {
        [Required]
        public ClienteDto Cliente { get; set; }
    }
}
