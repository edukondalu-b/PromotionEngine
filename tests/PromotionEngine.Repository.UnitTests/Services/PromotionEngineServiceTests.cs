using PromotionEngine.Domain.Enums;
using PromotionEngine.IRepository.IServices;
using PromotionEngine.Repository.Services;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Repository.UnitTests.Services
{
    public class PromotionEngineServiceTests
    {
        private readonly IPromotionEngineService _promotionEngineService;

        private readonly IPromotionCategoryService _promotionCategoryService;

        private static IPromotionService _promotionService;

        private const decimal sku_A_UnitPrice = 50;
        private const decimal sku_B_UnitPrice = 30;
        private const decimal sku_C_UnitPrice = 20;
        private const decimal sku_D_UnitPrice = 15;

        public PromotionEngineServiceTests(IPromotionService promotionService, IPromotionEngineService promotionEngineService, IPromotionCategoryService promotionCategoryService)
        {
            _promotionService = promotionService;

            _promotionEngineService = promotionEngineService;

            _promotionCategoryService = promotionCategoryService;
        }

        [Fact]
        public void ShouldReturnOneHundredForScenarioA()
        {
            // Arrange
            List<ICartOrderService> orders = new List<ICartOrderService>
            {
                new SKUACartOrderService(_promotionCategoryService) { SKU = SKU.A, UnitPrice = sku_A_UnitPrice, Quantity = 1},
                new SKUBCartOrderService(_promotionCategoryService) { SKU = SKU.B, UnitPrice = sku_B_UnitPrice, Quantity = 1},
                new SKUCCartOrderService(_promotionCategoryService) { SKU = SKU.C, UnitPrice = sku_C_UnitPrice, Quantity = 1}
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
            List<ICartOrderService> orders = new List<ICartOrderService>
            {
                new SKUACartOrderService(_promotionCategoryService) { SKU = SKU.A, UnitPrice = sku_A_UnitPrice, Quantity = 5},
                new SKUBCartOrderService(_promotionCategoryService) { SKU = SKU.B, UnitPrice = sku_B_UnitPrice, Quantity = 5},
                new SKUCCartOrderService(_promotionCategoryService) { SKU = SKU.C, UnitPrice = sku_C_UnitPrice, Quantity = 1}
            };

            //Act
            decimal totalOrderAmount = _promotionEngineService.CalculateTotalOrderValue(orders);

            //Assert
            Assert.True(totalOrderAmount > 0);
            Assert.Equal(370, totalOrderAmount);
        }


        [Fact]
        public void ShouldReturnTwoHundredAndEightyForScenarioC()
        {
            // Arrange
            List<ICartOrderService> orders = new List<ICartOrderService>
            {
                new SKUACartOrderService(_promotionCategoryService) { SKU = SKU.A, UnitPrice = sku_A_UnitPrice, Quantity = 3},
                new SKUBCartOrderService(_promotionCategoryService) { SKU = SKU.B, UnitPrice = sku_B_UnitPrice, Quantity = 5},
                new SKUCCartOrderService(_promotionCategoryService) { SKU = SKU.C, UnitPrice = sku_C_UnitPrice, Quantity = 1},
                new SKUDCartOrderService(_promotionCategoryService) { SKU = SKU.D, UnitPrice = sku_D_UnitPrice, Quantity = 1}
            };

            //Act
            decimal totalOrderAmount = _promotionEngineService.CalculateTotalOrderValue(orders);

            //Assert
            Assert.True(totalOrderAmount > 0);
            Assert.Equal(280, totalOrderAmount);
        }


        [Fact]
        public void ShouldReturnThreeHundredAndTenForScenarioD()
        {
            // Arrange
            List<ICartOrderService> orders = new List<ICartOrderService>
            {
                new SKUACartOrderService(_promotionCategoryService) { SKU = SKU.A, UnitPrice = sku_A_UnitPrice, Quantity = 3},
                new SKUBCartOrderService(_promotionCategoryService) { SKU = SKU.B, UnitPrice = sku_B_UnitPrice, Quantity = 5},
                new SKUCCartOrderService(_promotionCategoryService) { SKU = SKU.C, UnitPrice = sku_C_UnitPrice, Quantity = 2},
                new SKUDCartOrderService(_promotionCategoryService) { SKU = SKU.D, UnitPrice = sku_D_UnitPrice, Quantity = 2}
            };

            //Act
            decimal totalOrderAmount = _promotionEngineService.CalculateTotalOrderValue(orders);

            //Assert
            Assert.True(totalOrderAmount > 0);
            Assert.Equal(310, totalOrderAmount);
        }


        [Fact]
        public void ShouldReturnTwoHundredAndFiftyFiveForScenarioE()
        {
            // Arrange
            List<ICartOrderService> orders = new List<ICartOrderService>
            {
                new SKUACartOrderService(_promotionCategoryService) { SKU = SKU.A, UnitPrice = sku_A_UnitPrice, Quantity = 4},
                new SKUBCartOrderService(_promotionCategoryService) { SKU = SKU.B, UnitPrice = sku_B_UnitPrice, Quantity = 1},
                new SKUCCartOrderService(_promotionCategoryService) { SKU = SKU.C, UnitPrice = sku_C_UnitPrice, Quantity = 1},
                new SKUDCartOrderService(_promotionCategoryService) { SKU = SKU.D, UnitPrice = sku_D_UnitPrice, Quantity = 2}
            };

            //Act
            decimal totalOrderAmount = _promotionEngineService.CalculateTotalOrderValue(orders);

            //Assert
            Assert.True(totalOrderAmount > 0);
            Assert.Equal(255, totalOrderAmount);
        }
    }
}
