using System;
using System.Collections.Generic;
using Judini.Client.Modelos;
using Microsoft.AspNetCore.Components.Routing;
using MudBlazor;

namespace Judini.Client.Servicios
{
    public class MenuService : IMenuService
    {
        private IEnumerable<MenuItem> Items { get; }
        
        public MenuService()
        {
            this.Items = new List<MenuItem>
            {
                new MenuItem
                {
                    Ruta = "",
                    Match = NavLinkMatch.All,
                    Icono = Icons.Material.Filled.Home,
                    Nombre = "Home"
                },
                new MenuItem
                {
                    Ruta = "/counter",
                    Match = NavLinkMatch.Prefix,
                    Icono = Icons.Material.Filled.Add,
                    Nombre = "Counter"
                },
                new MenuItem
                {
                    Ruta = "/fetchdata",
                    Match = NavLinkMatch.Prefix,
                    Icono = Icons.Material.Filled.List,
                    Nombre = "Fetch data"
                },
                new MenuItem
                {
                    Ruta = "#",
                    Match = NavLinkMatch.Prefix,
                    Icono = Icons.Material.Outlined.Person,
                    Nombre = "Clientes",
                    Hijos = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Ruta = "/clientes/agregar",
                            Match = NavLinkMatch.Prefix,
                            Icono = Icons.Material.Filled.PersonAdd,
                            Nombre = "Agregar"
                        }
                    }
                }
            };
        }

        public IEnumerable<MenuItem> ObtenerItems()
        {
            return this.Items;
        }

        public IEnumerable<MenuItem> ObtenerCamino(Type paginaActual)
        {
            return this.Items;
        }
    }
}
