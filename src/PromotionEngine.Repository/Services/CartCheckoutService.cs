using PromotionEngine.Domain.Dtos;
using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using PromotionEngine.IRepository.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Repository.Services
{
    /// <summary>
    /// Cart Checkout Service - Mainly for Console UI
    /// </summary>
    public class CartCheckoutService : ICartCheckoutService
    {
        /// initialize promotion category service
        /// </summary>
        private readonly IPromotionCategoryService _promotionCategoryService;

        public CartCheckoutService(IPromotionCategoryService promotionCategoryService)
        {
            _promotionCategoryService = promotionCategoryService;
        }

        /// <summary>
        /// Get IEnumerable<ICartOrderService> based on selected scenario's available
        /// </summary>
        /// <param name="scenario"></param>
        /// <returns>IEnumerable<ICartOrderService></returns>
        public List<ICartOrderService> GetCartOrdersList(int scenario)
        {
            IEnumerable<ICartOrderService> returnOrders = new List<ICartOrderService>();
            IEnumerable<SKU_UnitPrice> skuList = (new SKU_UnitPriceDto()).SkuUnitPrice;
            decimal SKU_A_UP = skuList.Where(e => e.SKU == SKU.A).Select(k => k.UnitPrice).FirstOrDefault();
            decimal SKU_B_UP = skuList.Where(e => e.SKU == SKU.B).Select(k => k.UnitPrice).FirstOrDefault();
            decimal SKU_C_UP = skuList.Where(e => e.SKU == SKU.C).Select(k => k.UnitPrice).FirstOrDefault();
            decimal SKU_D_UP = skuList.Where(e => e.SKU == SKU.D).Select(k => k.UnitPrice).FirstOrDefault();
            switch (scenario)
            {
                case 1:
                    returnOrders = new List<ICartOrderService>()
                    {
                       new SKUACartOrderService(_promotionCategoryService) {Quantity = 1, SKU = SKU.A,UnitPrice =  SKU_A_UP},
                       new SKUBCartOrderService(_promotionCategoryService) {Quantity = 1, SKU = SKU.B, UnitPrice=SKU_B_UP },
                       new SKUCCartOrderService(_promotionCategoryService) {Quantity = 1, SKU = SKU.C, UnitPrice =SKU_C_UP, IgnoreComboPromotion = true }
                    };
                    Console.WriteLine("Scenario A");
                    break;
                case 2:
                    returnOrders = new List<ICartOrderService>()
                    {
                       new SKUACartOrderService(_promotionCategoryService) {Quantity = 5, SKU = SKU.A ,UnitPrice =  SKU_A_UP},
                       new SKUBCartOrderService(_promotionCategoryService) {Quantity = 5, SKU = SKU.B, UnitPrice=SKU_B_UP },
                       new SKUCCartOrderService(_promotionCategoryService) {Quantity = 1, SKU = SKU.C, UnitPrice =SKU_C_UP,IgnoreComboPromotion = true }
                    };
                    Console.WriteLine("Scenario B");
                    break;
                case 3:
                    returnOrders = new List<ICartOrderService>()
                    {
                       new SKUACartOrderService(_promotionCategoryService) {Quantity = 3, SKU = SKU.A ,UnitPrice =  SKU_A_UP},
                       new SKUBCartOrderService(_promotionCategoryService) {Quantity = 5, SKU = SKU.B , UnitPrice=SKU_B_UP},
                       new SKUCCartOrderService(_promotionCategoryService) {Quantity = 1, SKU = SKU.C, UnitPrice =SKU_C_UP,IgnoreComboPromotion = false },
                       new SKUDCartOrderService(_promotionCategoryService) {Quantity = 1, SKU = SKU.D, UnitPrice=SKU_D_UP,IgnoreComboPromotion = true }
                    };
                    Console.WriteLine("Scenario C");
                    break;
                default:
                    returnOrders = null;
                    Console.WriteLine("Please enter a valid selection between 1 to 3");
                    break;
            }
            return returnOrders?.OrderBy(e => e.SKU).ToList();
        }
    }
}
