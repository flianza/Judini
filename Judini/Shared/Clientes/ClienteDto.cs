using System;
using System.ComponentModel.DataAnnotations;

namespace Judini.Shared.Clientes
{
    public class ClienteDto
    {
        [Required]
        public long? Dni { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public DateTime? FechaDeNacimiento { get; set; }
        public string Email { get; set; }
        [Required]
        public string CodigoArea { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        public string NumeroCalle { get; set; }
        public string Departamento { get; set; }
        [Required]
        public string Ciudad { get; set; }
        public string Observaciones { get; set; }
    }
}
