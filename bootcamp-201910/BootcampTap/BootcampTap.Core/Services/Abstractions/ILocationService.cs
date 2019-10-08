using System.Threading;
using System.Threading.Tasks;
using BootcampTap.Core.Models;

namespace BootcampTap.Core.Services.Abstractions
{
    public interface ILocationService
    {
        Task<Geolocation> GetLocationAsync(string address, CancellationToken ct = default);
    }
}