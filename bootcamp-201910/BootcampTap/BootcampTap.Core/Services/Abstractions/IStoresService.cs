using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BootcampTap.Core.Models;

namespace BootcampTap.Core.Services.Abstractions
{
    public interface IStoresService
    {
        /// <summary>
        /// Get all the stores.
        /// </summary>
        /// <returns>The list of stores</returns>
        Task<List<Store>> GetStoresAsync(CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Get one store, provided it's Id
        /// </summary>
        /// <param name="storeId">Store Id that needs to be retrieved</param>
        /// <param name="ct">Task cancellation token</param>
        /// <returns></returns>
        Task<Store> GetStoreByIdAsync(string storeId, CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Create a new store.
        /// The provided store will have its Id filled automatically if it succeeds.
        /// </summary>
        /// <param name="store"></param>
        /// <param name="ct"></param>
        Task CreateStoreAsync(Store store, CancellationToken ct = default(CancellationToken));

        Task CreateStoreAsync(string name, string address, string phone, string photoUrl, string lat, string lng, CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Deletes a store.
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="ct"></param>
        Task DeleteStoreAsync(string storeId, CancellationToken ct = default(CancellationToken));
    }
}