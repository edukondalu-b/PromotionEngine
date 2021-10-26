using System;

namespace PromotionEngine.Domain.Models
{
    /// <summary>
    /// Cart item
    /// </summary>
    public class CartItem : SKU_UnitPrice
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }
    }
}
