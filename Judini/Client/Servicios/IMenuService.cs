using System;
using System.Collections.Generic;
using Judini.Client.Modelos;

namespace Judini.Client.Servicios
{
    public interface IMenuService
    {
        IEnumerable<MenuItem> ObtenerItems();
        IEnumerable<MenuItem> ObtenerCamino(Type paginaActual);
    }
}
