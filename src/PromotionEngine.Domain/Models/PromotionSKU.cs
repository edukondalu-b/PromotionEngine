using PromotionEngine.Domain.Enums;
using System;

namespace PromotionEngine.Domain.Models
{
    /// <summary>
    /// Promotion SKU
    /// </summary>
    public class PromotionSKU
    {
        /// <summary>
        /// Promotion Id
        /// </summary>
        public Guid PromotionId { get; set; }

        /// <summary>
        /// SKU Item
        /// </summary>
        public SKU SKU { get; set; }
    }
}
