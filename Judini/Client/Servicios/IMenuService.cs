using System;
using System.Collections.Generic;
using Judini.Client.Modelos.Menu;

namespace Judini.Client.Servicios
{
    public interface IMenuService
    {
        IEnumerable<Item> ObtenerItems();
        IEnumerable<Item> ObtenerCamino(Type paginaActual);
    }
}
