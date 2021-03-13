using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Routing;

namespace Judini.Client.Modelos.Menu
{
    public class Item
    {
        public string Ruta { get; set; }
        public NavLinkMatch Match { get; set; }
        public bool EsSeccion { get; set; }
        public string Nombre { get; set; }
        public string Icono { get; set; }
        public IEnumerable<Item> Hijos { get; set; } = Array.Empty<Item>();
        public Type Pagina { get; set; }
    }
}
