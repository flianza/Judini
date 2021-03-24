using System;

namespace Judini.Server.Dominio.Turnos
{
    public class Turno
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime Inicio { get; protected set; }
        public virtual DateTime Fin { get; protected set; }
        public virtual string Nombre { get; protected set; }
        public virtual string Notas { get; protected set; }

        protected Turno() { }
        public Turno(Shared.Turnos.Turno turno)
        {
            this.Inicio = turno.Inicio;
            this.Fin = turno.Fin;
            this.Nombre = turno.Nombre;
            this.Notas = turno.Notas;
        }
    }
}
