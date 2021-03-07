using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Routing;

namespace Judini.Client.Modelos
{
    public class MenuItem
    {
        public string Ruta { get; set; }
        public NavLinkMatch Match { get; set; }
        public string Nombre { get; set; }
        public string Icono { get; set; }
        public IEnumerable<MenuItem> Hijos { get; set; } = Array.Empty<MenuItem>();
    }
}
