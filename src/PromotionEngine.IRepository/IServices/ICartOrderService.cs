using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using System.Collections.Generic;

namespace PromotionEngine.IRepository.IServices
{
    /// <summary>
    /// Cart order service interface
    /// </summary>
    public interface ICartOrderService
    {
        /// <summary>
        /// SKU
        /// </summary>
        SKU SKU { get; set; }

        /// <summary>
        /// Unit Price
        /// </summary>
        decimal UnitPrice { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        int Quantity { get; set; }

        /// <summary>
        /// Ignore Combo Promotion
        /// </summary>
        bool IgnoreComboPromotion { get; set; }


        /// <summary>
        ///  Calculate Order Value and return CartOrderResult object
        /// </summary>
        /// <param name="cartOrders"></param>
        /// <returns>CartOrderResult</returns>
        CartOrderResult CalculateOrderValue(List<ICartOrderService> cartOrders);
    }
}
