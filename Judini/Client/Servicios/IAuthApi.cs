using System.Threading.Tasks;
using Judini.Shared.Requests;
using Judini.Shared.Responses;

namespace Judini.Client.Servicios
{
    public interface IAuthApi
    {
        Task IniciarSesion(IniciarSesionRequest iniciarSesionRequest);
        Task CerrarSesion();
        Task RegistrarUsuario(RegistrarUsuarioRequest registrarUsuarioRequest);
        Task<SesionActualResponse> ObtenerSesion();
    }
}
