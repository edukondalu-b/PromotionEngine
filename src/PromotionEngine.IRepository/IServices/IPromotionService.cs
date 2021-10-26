using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using System.Collections.Generic;

namespace PromotionEngine.IRepository.IServices
{
    /// <summary>
    /// Promotion Service interface
    /// </summary>
    public interface IPromotionService
    {
        /// <summary>
        /// Get active promotions
        /// </summary>
        /// <returns>IEnumerable<Promotion></returns>
        IEnumerable<Promotion> GetActivePromotions();

        /// <summary>
        /// Get promotion which can be applicable to cart orders SKU items
        /// </summary>
        /// <param name="cartOrders"></param>
        /// <returns>Promotion</returns>
        Promotion GetApplicablePromotionForCartOrders(IEnumerable<ICartOrderService> cartOrders);

        /// <summary>
        /// Add the applied promotion SKU for checking the mutual exclusive condition for following items in the cart
        /// </summary>
        /// <param name="skuItems"></param>
        void AddSKUToAppliedPromotions(IEnumerable<SKU> skuItems);
    }
}
