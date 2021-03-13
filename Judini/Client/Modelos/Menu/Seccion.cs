using System.Collections.Generic;

namespace Judini.Client.Modelos.Menu
{
    public class Seccion : Item
    {
        public Seccion(string nombre, IEnumerable<Item> hijos)
        {
            this.EsSeccion = true;
            this.Nombre = nombre;
            this.Hijos = hijos;
        }
    }
}
