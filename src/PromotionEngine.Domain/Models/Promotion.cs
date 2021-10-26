using PromotionEngine.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PromotionEngine.Domain.Models
{
    /// <summary>
    /// Promotion
    /// </summary>
    public class Promotion
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Promotion Name
        /// </summary>
        public string PromotionName { get; set; }

        /// <summary>
        /// Promotion Category
        /// </summary>
        public PromotionCategory PromotionCategory { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Promotion SKU Id's
        /// </summary>
        public List<SKU> PromotionSKUId { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Fixed Price of promotion
        /// </summary>
        public decimal FixedPrice { get; set; }
    }
}