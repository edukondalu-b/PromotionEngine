using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Domain.Dtos
{
    public class PromotionDto
    {

        private readonly List<string> randomGuids = new List<string> { "c3253f17-83b3-41b4-8669-33cc6a09459f", "54b129d9-f118-4bd7-be24-4dcca2fec631", "8c87b0b5-aae6-4e2c-9c6d-a22b34dff592" };

        private IEnumerable<Promotion> promotions;

        IEnumerable<PromotionSKU> _promotionSkuItems;

        public PromotionDto()
        {
            _promotionSkuItems = new List<PromotionSKU>
            {
                new PromotionSKU{PromotionId = Guid.Parse(randomGuids[0]), SKU = SKU.A},
                new PromotionSKU{PromotionId = Guid.Parse(randomGuids[1]), SKU = SKU.B},
                new PromotionSKU{PromotionId = Guid.Parse(randomGuids[2]), SKU = SKU.C},
                new PromotionSKU{PromotionId = Guid.Parse(randomGuids[2]), SKU = SKU.D}
            };

            promotions = new List<Promotion>
            {
                new Promotion() {Id = Guid.Parse(randomGuids[0]), PromotionName="3 A's For 130", PromotionCategory=PromotionCategory.StandardDiscountOnNItemsOfSameSKU,
                    IsActive=true, PromotionSKUId= _promotionSkuItems.Where(e=>e.PromotionId == Guid.Parse(randomGuids[0])).Select(k=>k.SKU).ToList(),Quantity=3, FixedPrice=130 },
                new Promotion() {Id = Guid.Parse(randomGuids[1]),PromotionName="2 B's For 45", PromotionCategory=PromotionCategory.StandardDiscountOnNItemsOfSameSKU,
                    IsActive=true, PromotionSKUId= _promotionSkuItems.Where(e=>e.PromotionId == Guid.Parse(randomGuids[1])).Select(k=>k.SKU).ToList(),Quantity=2, FixedPrice=45},
                new Promotion() {Id = Guid.Parse(randomGuids[2]),PromotionName="C & D For 30", PromotionCategory=PromotionCategory.StandardDiscountOnCombinationOfTwoOrMoreSKU,
                    IsActive=true, PromotionSKUId= _promotionSkuItems.Where(e=>e.PromotionId == Guid.Parse(randomGuids[2])).Select(k=>k.SKU).ToList(), Quantity=null, FixedPrice=30}
            };
        }

        public IEnumerable<Promotion> Promotions { get => this.promotions; }
    }
}
