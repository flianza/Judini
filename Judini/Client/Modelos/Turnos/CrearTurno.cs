using System;

namespace Judini.Client.Modelos.Turnos
{
    public class CrearTurno
    {
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public int? DuracionEnMinutos { get; set; }
        public string Nombre { get; set; }
        public DateTime Inicio
        {
            get
            {
                return this.Fecha.Value.Add(this.Hora.Value);
            }
        }
        public DateTime Fin
        {
            get
            {
                return this.Inicio.AddMinutes(this.DuracionEnMinutos.Value);
            }
        }
    }
}
