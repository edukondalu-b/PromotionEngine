using System.Collections.Generic;

namespace PromotionEngine.IRepository.IServices
{
    /// <summary>
    /// Promotion engine service interface
    /// </summary>
    public interface IPromotionEngineService
    {
        /// <summary>
        /// Calculate total cart order value
        /// </summary>
        /// <param name="cartOrders"></param>
        /// <returns>decimal</returns>
        decimal CalculateTotalOrderValue(List<ICartOrderService> cartOrders);
    }
}
