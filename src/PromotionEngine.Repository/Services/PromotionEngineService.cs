using PromotionEngine.Domain.Models;
using PromotionEngine.IRepository.IServices;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Repository.Services
{
    /// <summary>
    /// Promotion Engine Service
    /// </summary>
    public class PromotionEngineService : IPromotionEngineService
    {
        /// <summary>
        /// total cart order amount
        /// </summary>
        private decimal _totalCartOrderAmount;

        /// <summary>
        /// cart orders
        /// </summary>
        private List<ICartOrderService> _cartOrders;

        public PromotionEngineService()
        {
            _totalCartOrderAmount = 0;

            _cartOrders = new List<ICartOrderService>();
        }

        /// <summary>
        /// Calculate total cart order value
        /// </summary>
        /// <param name="cartOrders"></param>
        /// <returns>decimal</returns>
        public decimal CalculateTotalOrderValue(List<ICartOrderService> cartOrders)
        {

            if (cartOrders == null) return _totalCartOrderAmount;

            _cartOrders = cartOrders;

            do
            {
                ICartOrderService cartOrder = _cartOrders.FirstOrDefault();
                CartOrderResult cartOrderResult = cartOrder.CalculateOrderValue(new List<ICartOrderService> { cartOrder });
                if (cartOrderResult != null)
                {
                    if (cartOrderResult.AmountCalculated)
                    {
                        AddToFinalAmountAndRemoveOrder(cartOrderResult.CalculatedAmount, new List<ICartOrderService> { cartOrder });
                    }
                    if (cartOrderResult.IsComboItemsPromotion)
                    {
                        List<ICartOrderService> comboOrders = _cartOrders.Where(e => cartOrderResult.Promotion.PromotionSKUId.Contains(e.SKU)).ToList();
                        if (comboOrders.Select(e => e.SKU).Distinct().Count() == cartOrderResult.Promotion.PromotionSKUId.Count())
                        {
                            comboOrders.ForEach(e => e.IgnoreComboPromotion = true);
                            cartOrderResult = comboOrders.LastOrDefault()?.CalculateOrderValue(comboOrders);
                            if (cartOrderResult.AmountCalculated)
                            {
                                AddToFinalAmountAndRemoveOrder(cartOrderResult.CalculatedAmount, comboOrders);
                            }
                        }
                        else
                        {
                            comboOrders[0].IgnoreComboPromotion = true;
                            cartOrderResult = comboOrders[0].CalculateOrderValue(new List<ICartOrderService> { comboOrders[0] });
                            if (cartOrderResult.AmountCalculated)
                            {
                                AddToFinalAmountAndRemoveOrder(cartOrderResult.CalculatedAmount, new List<ICartOrderService> { comboOrders[0] });
                            }
                        }
                    }
                }
            } while (_cartOrders.Any());

            return _totalCartOrderAmount;
        }

        /// <summary>
        /// Add to total amount and remove calculated order
        /// </summary>
        /// <param name="calculatedAmount"></param>
        /// <param name="cartOrderItems"></param>
        private void AddToFinalAmountAndRemoveOrder(decimal calculatedAmount, IEnumerable<ICartOrderService> cartOrderItems)
        {
            _totalCartOrderAmount += calculatedAmount;
            _cartOrders = _cartOrders.Where(e => !cartOrderItems.Where(k => k.SKU == e.SKU).Any()).ToList();
        }
    }
}