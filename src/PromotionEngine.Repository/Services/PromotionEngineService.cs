using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using PromotionEngine.IRepository.IServices;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Repository.Services
{
    public class PromotionEngineService
    {
        // track the applied promotions on individual SKU's for checking the mutual exclusive condition
        private static List<SKU> _appliedPromotions;

        private readonly IPromotionService _promotionService;

        public PromotionEngineService()
        {
            _appliedPromotions = new List<SKU>();
            _promotionService = new PromotionService();
        }

        public decimal CalculateTotalOrderValue(List<Order> cartOrders)
        {
            decimal totalAmount = 0;

            if (cartOrders == null) return totalAmount;

            foreach (Order cartOrder in cartOrders)
            {
                Promotion promotion = _promotionService.GetActivePromotions().Where(e => e.PromotionSKUId == cartOrder.SKU && !_appliedPromotions.Where(e => e == cartOrder.SKU).Any()).FirstOrDefault();
                if (promotion != null)
                {
                    if (promotion.PromotionCategory == PromotionCategory.StandardDiscountOnNItemsOfSameSKU)
                    {
                        if ((cartOrder.Quantity / promotion.Quantity) > 0)
                        {
                            decimal numOfDists = (cartOrder.Quantity / promotion.Quantity.Value);
                            totalAmount += numOfDists * promotion.FixedPrice;
                            if ((cartOrder.Quantity % promotion.Quantity) > 0)
                            {
                                decimal remaining = (cartOrder.Quantity % promotion.Quantity.Value);
                                totalAmount += remaining * cartOrder.UnitPrice;
                            }
                            _appliedPromotions.Add(cartOrder.SKU);
                        }
                        else
                        {
                            totalAmount += cartOrder.Quantity * cartOrder.UnitPrice;
                        }
                    }
                }
                else
                {
                    totalAmount += cartOrder.Quantity * cartOrder.UnitPrice;
                }
            }

            return totalAmount;
        }
    }
}