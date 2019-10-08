using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BootcampTap.Core.Models;
using BootcampTap.Core.Services.Abstractions;

namespace BootcampTap.Core.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IHttpRequestService _httpRequestService;

        public AuthService(IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
        }

        public async Task LoginAsync(string username, string password, CancellationToken ct = default(CancellationToken))
        {
            var user = new User()
            {
                Username = username,
                Password = password
            };

            var result = await _httpRequestService.PostAsync<User>("Users/Login", user, ct);
            Debug.WriteLine("Login successful");
        }

        public Task LogoutAsync(CancellationToken ct = default(CancellationToken))
        {
            return Task.CompletedTask;
        }

        public bool IsUserAuthenticated()
        {
            return true;
        }

        public UserType GetAuthenticatedUserType()
        {
            return UserType.Admin;
        }
    }
}