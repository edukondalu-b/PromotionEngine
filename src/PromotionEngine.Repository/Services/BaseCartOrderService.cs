using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using PromotionEngine.IRepository.IServices;
using System.Collections.Generic;

namespace PromotionEngine.Repository.Services
{
    /// <summary>
    /// Base Cart Order Service
    /// </summary>
    public class BaseCartOrderService : ICartOrderService
    {
        /// <summary>
        /// SKU
        /// </summary>
        public SKU SKU { get; set; }

        /// <summary>
        /// Unit Price
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Ignore Combo Promotion
        /// </summary>
        public bool IgnoreComboPromotion { get; set; }

        /// <summary>
        /// initialize promotion category service
        /// </summary>
        private readonly IPromotionCategoryService _promotionCategoryService;

        public BaseCartOrderService(IPromotionCategoryService promotionCategoryService)
        {
            _promotionCategoryService = promotionCategoryService;
        }

        public BaseCartOrderService() { }

        /// <summary>
        ///  Calculate Order Value and return CartOrderResult object
        /// </summary>
        /// <param name="cartOrders"></param>
        /// <returns>CartOrderResult</returns>
        public CartOrderResult CalculateOrderValue(List<ICartOrderService> cartOrders)
        {
            CartOrderResult returnData = _promotionCategoryService.CalculatePriceForPromotionCategory(cartOrders);
            return returnData;
        }
    }
}
