using System;
using Microsoft.AspNetCore.Components.Routing;

namespace Judini.Client.Modelos.Menu
{
    public class Link : Item
    {
        public Link(string nombre, string ruta, NavLinkMatch match, string icono, Type pagina)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
            this.Match = match;
            this.Icono = icono;
            this.Pagina = pagina;
        }
    }
}
