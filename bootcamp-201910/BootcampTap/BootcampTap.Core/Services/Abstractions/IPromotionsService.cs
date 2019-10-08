using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BootcampTap.Core.Models;

namespace BootcampTap.Core.Services.Abstractions
{
    public interface IPromotionsService
    {
        /// <summary>
        /// Get all the promotions.
        /// </summary>
        /// <param name="storeId">Specify the Id of the store the retrieved promotions are associated with.</param>
        /// <returns>The list of promotions</returns>
        Task<List<Promotion>> GetPromotionsAsync(string storeId = null, CancellationToken ct = default);

        /// <summary>
        /// Create a new promotion.
        /// The provided promotion will have its Id filled automatically if it succeeds.
        /// </summary>
        /// <param name="promotion"></param>
        Task CreatePromotionAsync(Promotion promotion, CancellationToken ct = default);

        /// <summary>
        /// Create  new promotion.
        /// </summary>
        /// <param name="product">Name of the product</param>
        /// <param name="storeId">Id of the store this promotion is associated with</param>
        /// <param name="discount">The product discount</param>
        /// <returns></returns>
        Task CreatePromotionAsync(string product, string storeId, int discount, CancellationToken ct = default);


        /// <summary>
        /// Deletes a promotion.
        /// </summary>
        /// <param name="promotionId"></param>
        Task DeletePromotionAsync(string promotionId, CancellationToken ct = default);
    }
}