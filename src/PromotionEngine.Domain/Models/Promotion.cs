using PromotionEngine.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PromotionEngine.Domain.Models
{
    public class Promotion
    {
        public Guid Id { get; set; }

        public string PromotionName { get; set; }

        public PromotionCategory PromotionCategory { get; set; }

        public bool IsActive { get; set; }

        public List<SKU> PromotionSKUId { get; set; }

        public int? Quantity { get; set; }

        public decimal FixedPrice { get; set; }
    }
}