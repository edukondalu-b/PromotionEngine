using PromotionEngine.Domain.Enums;
using System.Collections.Generic;

namespace PromotionEngine.Domain.Models
{
    public class Promotion
    {
        public string PromotionName { get; set; }

        public PromotionCategory PromotionCategory { get; set; }

        public bool IsActive { get; set; }

        public SKU PromotionSKUId { get; set; }

        public int? Quantity { get; set; }

        public decimal FixedPrice { get; set; }
    }
}