using System.Threading;
using System.Threading.Tasks;
using BootcampTap.Core.Models;

namespace BootcampTap.Core.Services.Abstractions
{
    public interface IAuthService
    {
        Task LoginAsync(string username, string password, CancellationToken ct = default(CancellationToken));

        Task LogoutAsync(CancellationToken ct = default(CancellationToken));

        bool IsUserAuthenticated();

        UserType GetAuthenticatedUserType();
    }
}