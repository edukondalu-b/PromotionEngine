using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Repository.Services
{
    public class PromotionEngineServiceTests
    {
        PromotionEngineService _promotionEngineService;

        public PromotionEngineServiceTests()
        {
            _promotionEngineService = new PromotionEngineService();
        }

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
            decimal totalOrderAmount = _promotionEngineService.CalculateTotalOrderValue(orders);

            //Assert
            Assert.True(totalOrderAmount > 0);
            Assert.Equal(100, totalOrderAmount);
        }

        [Fact]
        public void ShouldReturnZeroForEmptyOrders()
        {
            //Act
            decimal totalOrderAmount = _promotionEngineService.CalculateTotalOrderValue(null);

            //Assert
            Assert.Equal(0, totalOrderAmount);
        }


        [Fact]
        public void ShouldReturnThreeHundredAndSeventyForScenarioB()
        {
            // Arrange
            List<Order> orders = new List<Order>
            {
                new Order { SKU = SKU.A, UnitPrice = 50, Quantity = 5},
                new Order { SKU = SKU.B, UnitPrice = 30, Quantity = 5},
                new Order { SKU = SKU.C, UnitPrice = 20, Quantity = 1}
            };

            //Act
            decimal totalOrderAmount = _promotionEngineService.CalculateTotalOrderValue(orders);

            //Assert
            Assert.True(totalOrderAmount > 0);
            Assert.Equal(370, totalOrderAmount);
        }
    }
}
