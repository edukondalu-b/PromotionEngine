namespace PromotionEngine.Domain.Models
{
    /// <summary>
    /// Cart Order Result
    /// </summary>
    public class CartOrderResult
    {
        /// <summary>
        /// Calculated Amount
        /// </summary>
        public decimal CalculatedAmount { get; set; }

        /// <summary>
        /// Amount Calculated
        /// </summary>

        public bool AmountCalculated { get; set; }

        /// <summary>
        /// Promotion Applied
        /// </summary>

        public bool PromotionApplied { get; set; }

        /// <summary>
        /// Promotion
        /// </summary>

        public Promotion Promotion { get; set; }

        /// <summary>
        /// Is Combo Items Promotion
        /// </summary>

        public bool IsComboItemsPromotion { get; set; }
    }
}
