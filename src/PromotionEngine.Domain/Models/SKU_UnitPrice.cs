using PromotionEngine.Domain.Enums;

namespace PromotionEngine.Domain.Models
{
    /// <summary>
    /// SKU Unit Price
    /// </summary>
    public class SKU_UnitPrice
    {
        /// <summary>
        /// SKU Item
        /// </summary>
        public SKU SKU { get; set; }

        /// <summary>
        /// Unit Price
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}
