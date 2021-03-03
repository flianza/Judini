using System.Collections.Generic;

namespace Judini.Shared.Responses
{
    public class SesionActualResponse
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
