namespace PromotionEngine.Domain.Enums
{
    /// <summary>
    /// Promotion Category
    /// </summary>
    public enum PromotionCategory
    {
        /// <summary>
        /// Standard discount on `N` items of same SKU
        /// </summary>
        StandardDiscountOnNItemsOfSameSKU = 1,

        /// <summary>
        /// Standard discount on combination of 2 or more SKU
        /// </summary>
        StandardDiscountOnCombinationOfTwoOrMoreSKU = 2,
    }
}
