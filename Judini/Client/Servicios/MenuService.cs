﻿using System;
using System.Collections.Generic;
using System.Linq;
using Judini.Client.Modelos.Menu;
using Microsoft.AspNetCore.Components.Routing;
using MudBlazor;

namespace Judini.Client.Servicios
{
    public class MenuService : IMenuService
    {
        private IEnumerable<Item> Items { get; }
        public MenuService()
        {
            this.Items = new List<Item>
            {
                new Seccion("Personal", new List<Item>
                {
                    new Link("Home", "", NavLinkMatch.All, Icons.Material.Filled.Home, typeof(Pages.Index)),
                    new Link("Counter", "/counter", NavLinkMatch.Prefix, Icons.Material.Filled.Add, typeof(Pages.Counter)),
                    new Link("Fetch data", "/fetchdata", NavLinkMatch.Prefix, Icons.Material.Filled.List, typeof(Pages.FetchData)),
                    new Agrupador("Clientes", Icons.Material.Outlined.Person, new List<Item> 
                    {
                        new Link("Agregar", "/clientes/agregar", NavLinkMatch.Prefix, Icons.Material.Filled.PersonAdd, typeof(Pages.Clientes.Agregar)),
                    })
                })
            };
        }

        public IEnumerable<Item> ObtenerItems()
        {
            return this.Items;
        }

        public IEnumerable<Item> ObtenerCamino(Type paginaActual)
        {
            return this.BuscarEnItems(paginaActual, this.Items).Reverse();
        }

        private IEnumerable<Item> BuscarEnItems(Type paginaABuscar, IEnumerable<Item> itemsABuscar)
        {
            foreach (var item in itemsABuscar)
            {
                if (item.Pagina == paginaABuscar)
                {
                    yield return item;
                }
                if (item.Hijos != null)
                {
                    var camino = this.BuscarEnItems(paginaABuscar, item.Hijos);

                    if (camino.Any())
                    {
                        foreach (var itemEnCamino in camino)
                        {
                            yield return itemEnCamino;
                        }
                        yield return item;
                    }
                }
            }
        }
    }
}
