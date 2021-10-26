using PromotionEngine.Domain.Models;
using System.Collections.Generic;

namespace PromotionEngine.IRepository.IServices
{
    /// <summary>
    /// Promotion Category Service interface
    /// </summary>
    public interface IPromotionCategoryService
    {
        /// <summary>
        /// Calculate order price by promotion category and return CartOrderResult
        /// </summary>
        /// <param name="cartOrders"></param>
        /// <returns>CartOrderResult</returns>
        CartOrderResult CalculatePriceForPromotionCategory(List<ICartOrderService> cartOrders);
    }
}
