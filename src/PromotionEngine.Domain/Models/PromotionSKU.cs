using PromotionEngine.Domain.Enums;
using System;

namespace PromotionEngine.Domain.Models
{
    public class PromotionSKU
    {
        public Guid PromotionId { get; set; }

        public SKU SKU { get; set; }
    }
}
