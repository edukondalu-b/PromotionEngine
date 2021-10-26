using PromotionEngine.Domain.Dtos;
using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using PromotionEngine.IRepository.IServices;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Repository.Services
{
    /// <summary>
    /// Promotion Service
    /// </summary>
    public class PromotionService : IPromotionService
    {
        /// <summary>
        /// Track the applied promotions on individual SKU's for checking the mutual exclusive condition
        /// </summary>
        private static List<SKU> _appliedPromotions;

        /// <summary>
        /// Maximun number of promotions cab be applied for each checkout
        /// </summary>
        private readonly int maximunPromotionsToApply = 3;

        public PromotionService()
        {
            _appliedPromotions = new List<SKU>();
        }

        /// <summary>
        /// Get active promotions
        /// </summary>
        /// <returns>IEnumerable<Promotion></returns>
        public IEnumerable<Promotion> GetActivePromotions()
        {
            return new PromotionDto().Promotions.Where(e => e.IsActive == true).ToList();
        }

        /// <summary>
        /// Get promotion which can be applicable to cart orders SKU items
        /// </summary>
        /// <param name="cartOrders"></param>
        /// <returns>Promotion</returns>
        public Promotion GetApplicablePromotionForCartOrders(IEnumerable<ICartOrderService> cartOrders)
        {
            Promotion promotion = GetActivePromotions().Where(e => cartOrders.Any(k => e.PromotionSKUId.Contains(k.SKU)) && !_appliedPromotions.Where(e => cartOrders.Any(l => l.SKU == e)).Any() && _appliedPromotions.Count() < maximunPromotionsToApply).FirstOrDefault();

            return promotion;
        }

        /// <summary>
        /// Add the applied promotion SKU for checking the mutual exclusive condition for following items in the cart
        /// </summary>
        /// <param name="skuItems"></param>
        public void AddSKUToAppliedPromotions(IEnumerable<SKU> skuItems)
        {
            if (skuItems != null)
            {
                _appliedPromotions.AddRange(skuItems);
            }
        }
    }
}
