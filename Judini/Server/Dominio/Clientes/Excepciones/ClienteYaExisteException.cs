using System;

namespace Judini.Server.Dominio.Clientes.Excepciones
{
    [Serializable]
    public class ClienteYaExisteException : Exception
    {
        public ClienteYaExisteException() { }
        public ClienteYaExisteException(string message) : base(message) { }
        public ClienteYaExisteException(string message, Exception innerException) : base(message, innerException) { }
    }
}
