using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Repository.Services
{
    public class PromotionEngineServiceTests
    {
        [Fact]
        public void ShouldReturnOneHundredForScenarioA()
        {
            // Arrange
            List<Order> orders = new List<Order>
            {
                new Order { SKU = SKU.A, UnitPrice = 50, Quantity = 1},
                new Order { SKU = SKU.B, UnitPrice = 30, Quantity = 1},
                new Order { SKU = SKU.C, UnitPrice = 20, Quantity = 1}
            };

            //Act
            PromotionEngineService promotionEngineService= new PromotionEngineService();
            decimal totalOrderAmount = promotionEngineService.CalculateTotalOrderValue(orders);

            //Assert
            Assert.True(totalOrderAmount > 0);
            Assert.Equal(100, totalOrderAmount);
        }
    }
}
