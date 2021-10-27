using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using PromotionEngine.IRepository.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Repository.Services
{
    /// <summary>
    /// Promotion Category Service
    /// </summary>
    public class PromotionCategoryService : IPromotionCategoryService
    {
        /// <summary>
        /// Initialize Promotion Service
        /// </summary>
        private readonly IPromotionService _promotionService;

        public PromotionCategoryService(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        /// <summary>
        /// Calculate order price by promotion category and return CartOrderResult object
        /// </summary>
        /// <param name="cartOrders"></param>
        /// <returns>CartOrderResult</returns>
        public CartOrderResult CalculatePriceForPromotionCategory(List<ICartOrderService> cartOrders)
        {
            CartOrderResult cartOrderResult = new CartOrderResult() { AmountCalculated = false, CalculatedAmount = 0, PromotionApplied = false, IsComboItemsPromotion = false };
            try
            {
                Promotion promotionCode = _promotionService.GetApplicablePromotionForCartOrders(cartOrders);
                if (promotionCode != null)
                {
                    if (promotionCode.PromotionCategory != PromotionCategory.StandardDiscountOnCombinationOfTwoOrMoreSKU || cartOrders.Where(e => e.IgnoreComboPromotion == true).Count() == cartOrders.Count())
                    {
                        switch (promotionCode.PromotionCategory)
                        {
                            case PromotionCategory.StandardDiscountOnNItemsOfSameSKU:

                                (cartOrderResult.CalculatedAmount, cartOrderResult.PromotionApplied) = StandardDiscountOnNItemsOfSameSKU(cartOrders[0], promotionCode);
                                break;
                            case PromotionCategory.StandardDiscountOnCombinationOfTwoOrMoreSKU:

                                (cartOrderResult.CalculatedAmount, cartOrderResult.PromotionApplied) = StandardDiscountOnCombinationOfTwoOrMoreSKU(cartOrders, promotionCode);
                                break;

                            default:
                                // do nothing
                                break;
                        }

                        cartOrderResult.AmountCalculated = true;

                        if (cartOrderResult.PromotionApplied)
                        {
                            _promotionService.AddSKUToAppliedPromotions(cartOrders.Select(e => e.SKU).ToList());
                        }
                    }
                    else
                    {
                        cartOrderResult.IsComboItemsPromotion = true;
                        cartOrderResult.Promotion = promotionCode;
                    }
                }
                else
                {
                    cartOrders.ForEach(k => cartOrderResult.CalculatedAmount += (k.UnitPrice * k.Quantity));
                    cartOrderResult.AmountCalculated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return cartOrderResult;
        }

        /// <summary>
        /// Return list of cart items based on quantity of SKU in the cart order
        /// </summary>
        /// <param name="cartOrders"></param>
        /// <returns>List<CartItem></returns>
        private List<CartItem> GenerateGuidForEachItem(List<ICartOrderService> cartOrders)
        {
            List<CartItem> returnData = new List<CartItem>();
            foreach (ICartOrderService cartOrder in cartOrders)
            {
                for (int i = 0; i < cartOrder.Quantity; i++)
                {
                    returnData.Add(new CartItem { SKU = cartOrder.SKU, Id = Guid.NewGuid(), UnitPrice = cartOrder.UnitPrice });
                }
            }
            return returnData;
        }

        /// <summary>
        /// Calculate order value when promotion is StandardDiscountOnNItemsOfSameSKU
        /// </summary>
        /// <param name="cartOrder"></param>
        /// <param name="promotion"></param>
        /// <returns>(calculatedAmount, promotionApplied)</returns>
        private (decimal, bool) StandardDiscountOnNItemsOfSameSKU(ICartOrderService cartOrder, Promotion promotion)
        {
            decimal calculatedAmount = 0;
            bool promotionApplied = false;
            int numberOfDisc = (cartOrder.Quantity / promotion.Quantity.Value);
            int remItems = (cartOrder.Quantity % promotion.Quantity.Value);
            if (numberOfDisc > 0)
            {
                calculatedAmount += numberOfDisc * promotion.FixedPrice;
                if (remItems > 0)
                {
                    calculatedAmount += remItems * cartOrder.UnitPrice;
                }
                promotionApplied = true;
            }
            else
            {
                calculatedAmount += cartOrder.Quantity * cartOrder.UnitPrice;
            }
            return (calculatedAmount, promotionApplied);
        }

        /// <summary>
        /// Calculate order value when promotion is StandardDiscountOnCombinationOfTwoOrMoreSKU
        /// </summary>
        /// <param name="cartOrders"></param>
        /// <param name="promotion"></param>
        /// <returns>(calculatedAmount, promotionApplied)</returns>
        private (decimal, bool) StandardDiscountOnCombinationOfTwoOrMoreSKU(List<ICartOrderService> cartOrders, Promotion promotion)
        {
            decimal calculatedAmount = 0;
            bool promotionApplied = false;
            List<CartItem> cartItems = GenerateGuidForEachItem(cartOrders);
            do
            {
                List<CartItem> comboCartOrder = new List<CartItem>();
                foreach (SKU sku in promotion.PromotionSKUId)
                {
                    CartItem cartItem = cartItems.Where(e => e.SKU == sku).FirstOrDefault();
                    if (cartItem != null)
                    {
                        comboCartOrder.Add(cartItem);
                    }
                }
                if (comboCartOrder.Count() == promotion.PromotionSKUId.Count)
                {
                    calculatedAmount += 1 * promotion.FixedPrice;
                    cartItems = cartItems.Where(e => !comboCartOrder.Where(k => k.Id == e.Id).Any()).ToList();
                    promotionApplied = true;
                }
                else
                {
                    cartItems.ForEach(k => calculatedAmount += (k.UnitPrice * 1));
                    cartItems = cartItems.Where(e => !cartItems.Where(k => k.Id == e.Id).Any()).ToList();
                }

            } while (cartItems.Any());

            return (calculatedAmount, promotionApplied);
        }
    }
}
