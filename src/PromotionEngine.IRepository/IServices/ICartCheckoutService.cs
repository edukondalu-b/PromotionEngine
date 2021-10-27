using System.Collections.Generic;

namespace PromotionEngine.IRepository.IServices
{
    /// <summary>
    /// Cart checkout service interface - Mainly for Console UI
    /// </summary>
    public interface ICartCheckoutService
    {
        /// <summary>
        /// Check out cart orders and calculate total amount based on selected scenario's available
        /// </summary>
        /// <param name="scenario"></param>
        /// <returns>decimal</returns>
        decimal CheckoutCartOrdersAndCalculateTotalAmount(int scenario);
    }
}
