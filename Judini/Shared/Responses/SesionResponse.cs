using System.Collections.Generic;

namespace Judini.Shared.Responses
{
    public class SesionResponse
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
