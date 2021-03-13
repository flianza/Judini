using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Routing;

namespace Judini.Client.Modelos.Menu
{
    public class Agrupador : Item
    {
        public Agrupador(string nombre, string icono, IEnumerable<Item> hijos)
        {
            this.Ruta = "#";
            this.Match = NavLinkMatch.Prefix;
            this.Icono = icono;
            this.Nombre = nombre;
            this.Hijos = hijos;
        }
    }
}
