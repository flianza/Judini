using System.Security.Claims;
using Judini.Shared.Responses;
using MediatR;

namespace Judini.Server.Queries
{
    public class SesionActualQuery : IRequest<SesionActualResponse>
    {
        public SesionActualQuery(ClaimsPrincipal user)
        {
            this.User = user;
        }

        public ClaimsPrincipal User { get; }
    }
}
