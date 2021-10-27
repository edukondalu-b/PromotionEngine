using PromotionEngine.Domain.Dtos;
using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using PromotionEngine.IRepository.IServices;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Repository.Services
{
    /// <summary>
    /// Cart Checkout Service - Mainly for Console UI
    /// </summary>
    public class CartCheckoutService : ICartCheckoutService
    {
        /// <summary>
        /// initialize promotion category service
        /// </summary>
        private readonly IPromotionCategoryService _promotionCategoryService;

        /// <summary>
        /// initialize promotion engine service
        /// </summary>
        private readonly IPromotionEngineService _promotionEngineService;


        public CartCheckoutService(IPromotionCategoryService promotionCategoryService, IPromotionEngineService promotionEngineService)
        {
            _promotionCategoryService = promotionCategoryService;
            _promotionEngineService = promotionEngineService;
        }

        /// <summary>
        /// Check out cart orders and calculate total amount based on selected scenario's available
        /// </summary>
        /// <param name="scenario"></param>
        /// <returns>decimal</returns>
        public decimal CheckoutCartOrdersAndCalculateTotalAmount(int scenario)
        {
            List<ICartOrderService> cartOrders = new List<ICartOrderService>();
            List<CartItem> cartOrderItems = (new CartOrderDto(scenario)).CartOrders;
            foreach (CartItem cartOrderItem in cartOrderItems)
            {
                ICartOrderService cartOrderService = cartOrderItem.SKU switch
                {
                    SKU.A => new SKUACartOrderService(_promotionCategoryService) { Quantity = cartOrderItem.Quantity, SKU = SKU.A, UnitPrice = cartOrderItem.UnitPrice },
                    SKU.B => new SKUBCartOrderService(_promotionCategoryService) { Quantity = cartOrderItem.Quantity, SKU = SKU.B, UnitPrice = cartOrderItem.UnitPrice },
                    SKU.C => new SKUCCartOrderService(_promotionCategoryService) { Quantity = cartOrderItem.Quantity, SKU = SKU.C, UnitPrice = cartOrderItem.UnitPrice },
                    SKU.D => new SKUDCartOrderService(_promotionCategoryService) { Quantity = cartOrderItem.Quantity, SKU = SKU.D, UnitPrice = cartOrderItem.UnitPrice },
                    _ => null
                };

                if (cartOrderService != null)
                {
                    cartOrders.Add(cartOrderService);
                }
            }
            cartOrders = cartOrders?.OrderBy(e => e.SKU).ToList();

            return _promotionEngineService.CalculateTotalOrderValue(cartOrders);
        }
    }
}
