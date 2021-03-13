using System;
using Judini.Shared.Clientes;

namespace Judini.Server.Dominio.Clientes
{
    public class Cliente
    {
        public virtual int Id { get; protected set; }
        public virtual long Dni { get; protected set; }
        public virtual string Nombre { get; protected set; }
        public virtual string Apellido { get; protected set; }
        public virtual DateTime? FechaDeNacimiento { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string CodigoArea { get; protected set; }
        public virtual string Telefono { get; protected set; }
        public virtual string Calle { get; protected set; }
        public virtual string NumeroCalle { get; protected set; }
        public virtual string Departamento { get; protected set; }
        public virtual string Ciudad { get; protected set; }
        public virtual string Observaciones { get; protected set; }

        protected Cliente() { }
        public Cliente(ClienteDto clienteDto)
        {
            this.Dni = clienteDto.Dni.Value;
            this.Nombre = clienteDto.Nombre;
            this.Apellido = clienteDto.Apellido;
            this.FechaDeNacimiento = clienteDto.FechaDeNacimiento;
            this.Email = clienteDto.Email;
            this.CodigoArea = clienteDto.CodigoArea;
            this.Telefono = clienteDto.Telefono;
            this.Calle = clienteDto.Calle;
            this.NumeroCalle = clienteDto.NumeroCalle;
            this.Departamento = clienteDto.Departamento;
            this.Ciudad = clienteDto.Ciudad;
            this.Observaciones = clienteDto.Observaciones;
        }
    }
}
