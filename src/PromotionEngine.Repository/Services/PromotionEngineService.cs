using PromotionEngine.Domain.Models;
using System.Collections.Generic;

namespace PromotionEngine.Repository.Services
{
    public class PromotionEngineService
    {
        public decimal CalculateTotalOrderValue(List<Order> cartOrders)
        {
            decimal totalAmount = 0;
            foreach (Order order in cartOrders)
            {
                Promotion promotion = null;
                if (promotion != null)
                {

                }
                else
                {
                    totalAmount += order.Quantity * order.UnitPrice;
                }
            }

            return totalAmount;
        }
    }
}