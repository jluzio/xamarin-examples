using System.Threading;
using System.Threading.Tasks;

namespace BootcampTap.Core.Services.Abstractions
{
    public interface IHttpRequestService
    {
        Task PostAsync(string resource, object body = null, CancellationToken ct = default);

        Task<T> PostAsync<T>(string resource, object body = null, CancellationToken ct = default);

        Task<T> GetAsync<T>(string resource, CancellationToken ct = default);

        Task PutAsync(string resource, object body, CancellationToken ct = default);

        Task<T> PutAsync<T>(string resource, object body, CancellationToken ct = default);
    }
}