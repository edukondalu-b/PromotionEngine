using System.Collections.Generic;

namespace PromotionEngine.IRepository.IServices
{
    /// <summary>
    /// Cart checkout service interface - Mainly for Console UI
    /// </summary>
    public interface ICartCheckoutService
    {
        /// <summary>
        /// Get cart orders list based on selected scenario's available
        /// </summary>
        /// <param name="scenario"></param>
        /// <returns>List<ICartOrderService></returns>
        List<ICartOrderService> GetCartOrdersList(int scenario);
    }
}
