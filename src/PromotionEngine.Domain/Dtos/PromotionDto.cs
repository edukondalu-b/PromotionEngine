using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using System.Collections.Generic;

namespace PromotionEngine.Domain.Dtos
{
    public class PromotionDto
    {
        private IEnumerable<Promotion> promotions;

        public PromotionDto()
        {
            promotions = new List<Promotion>
            {
                new Promotion() { PromotionName="3 A's For 130", PromotionCategory=PromotionCategory.StandardDiscountOnNItemsOfSameSKU,
                    IsActive=true, PromotionSKUId= SKU.A,Quantity=3, FixedPrice=130 },
                new Promotion() {PromotionName="2 B's For 45", PromotionCategory=PromotionCategory.StandardDiscountOnNItemsOfSameSKU,
                    IsActive=true, PromotionSKUId=  SKU.B,Quantity=2, FixedPrice=45},
            };
        }

        public IEnumerable<Promotion> Promotions { get => this.promotions; }
    }
}
