using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using PromotionEngine.IRepository.IServices;
using PromotionEngine.Repository.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PromotionEngine.Repository.UnitTests.Services
{
    public class PromotionServiceTests
    {
        private readonly IPromotionService _promotionService;

        public PromotionServiceTests(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [Fact]
        public void ShouldReturnThreeActivePromotions()
        {
            //Act
            int activePromotionsCount = _promotionService.GetActivePromotions().Count();

            //Assert
            Assert.True(activePromotionsCount > 0);
            Assert.Equal(3, activePromotionsCount);
        }

        [Fact]
        public void ShouldReturnThreeAFor130Promotion()
        {
            //Act
            Promotion activePromotion = _promotionService.GetApplicablePromotionForCartOrders(new List<ICartOrderService> { new SKUACartOrderService { SKU = SKU.A, UnitPrice = 50, Quantity = 1 } });

            //Assert
            Assert.NotNull(activePromotion);
            Assert.True(activePromotion.PromotionName == "3 A's For 130");
            Assert.Equal(new List<SKU> { SKU.A }, activePromotion.PromotionSKUId.ToList());
        }

        [Fact]
        public void ShouldReturnNullPromotion()
        {
            // Arrange
            _promotionService.AddSKUToAppliedPromotions(new List<SKU> { SKU.D });

            //Act
            Promotion activePromotion = _promotionService.GetApplicablePromotionForCartOrders(new List<ICartOrderService> { new SKUACartOrderService { SKU = SKU.D, UnitPrice = 15, Quantity = 1 } });

            //Assert
            Assert.Null(activePromotion);
        }

        [Fact]
        public void ShouldReturnNullPromotionAfterExceedingMaximumPromotionsApplied()
        {
            // Arrange
            _promotionService.AddSKUToAppliedPromotions(new List<SKU> { SKU.A, SKU.B, SKU.C });

            //Act
            Promotion activePromotion = _promotionService.GetApplicablePromotionForCartOrders(new List<ICartOrderService> { new SKUACartOrderService { SKU = SKU.A, UnitPrice = 50, Quantity = 1 } });

            //Assert
            Assert.Null(activePromotion);
        }
    }
}
