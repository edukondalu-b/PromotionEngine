using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using PromotionEngine.IRepository.IServices;
using PromotionEngine.Repository.Services;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Repository.UnitTests.Services
{
    public class PromotionCategoryServiceTests
    {
        private readonly IPromotionCategoryService _promotionCategoryService;

        private static IPromotionService _promotionService;

        private readonly List<ICartOrderService> _cartOrders;

        public PromotionCategoryServiceTests(IPromotionService promotionService, IPromotionCategoryService promotionCategoryService)
        {
            _promotionService = promotionService;

            _promotionCategoryService = promotionCategoryService;

            _cartOrders = new List<ICartOrderService>
            {
                new SKUACartOrderService { SKU = SKU.A, UnitPrice = 50, Quantity = 1},
                new SKUBCartOrderService { SKU = SKU.B, UnitPrice = 30, Quantity = 1},
                new SKUCCartOrderService { SKU = SKU.C, UnitPrice = 20, Quantity = 1},
                new SKUDCartOrderService { SKU = SKU.D, UnitPrice = 15, Quantity = 2}
            };
        }


        [Fact]
        public void ShouldReturnCardOrderResultObjectForSKUAWithoutApplyingPromotion()
        {
            //Arrange
            CartOrderResult expectedCartOrderResult = new CartOrderResult() { AmountCalculated = true, CalculatedAmount = 50, PromotionApplied = false, IsComboItemsPromotion = false };

            //Act
            CartOrderResult actualCartOrderResult = _promotionCategoryService.CalculatePriceForPromotionCategory(new List<ICartOrderService> { _cartOrders[0] });

            //Assert
            Assert.NotNull(actualCartOrderResult);
            Assert.Equal(expectedCartOrderResult.CalculatedAmount, actualCartOrderResult.CalculatedAmount);
            Assert.Equal(expectedCartOrderResult.AmountCalculated, actualCartOrderResult.AmountCalculated);
            Assert.Equal(expectedCartOrderResult.PromotionApplied, actualCartOrderResult.PromotionApplied);
            Assert.Equal(expectedCartOrderResult.IsComboItemsPromotion, actualCartOrderResult.IsComboItemsPromotion);
        }


        [Fact]
        public void ShouldReturnCardOrderResultObjectForSKUAWithAppliedPromotion()
        {
            //Arrange
            CartOrderResult expectedCartOrderResult = new CartOrderResult() { AmountCalculated = true, CalculatedAmount = 130, PromotionApplied = true, IsComboItemsPromotion = false };

            //Act
            CartOrderResult actualCartOrderResult = _promotionCategoryService.CalculatePriceForPromotionCategory(new List<ICartOrderService> { new SKUACartOrderService { SKU = SKU.A, UnitPrice = 50, Quantity = 3 } });

            //Assert
            Assert.NotNull(actualCartOrderResult);
            Assert.Equal(expectedCartOrderResult.CalculatedAmount, actualCartOrderResult.CalculatedAmount);
            Assert.Equal(expectedCartOrderResult.AmountCalculated, actualCartOrderResult.AmountCalculated);
            Assert.Equal(expectedCartOrderResult.PromotionApplied, actualCartOrderResult.PromotionApplied);
            Assert.Equal(expectedCartOrderResult.IsComboItemsPromotion, actualCartOrderResult.IsComboItemsPromotion);
        }


        [Fact]
        public void ShouldReturnCardOrderResultObjectForSKUCWithoutCalculatingAmount()
        {
            //Arrange
            CartOrderResult expectedCartOrderResult = new CartOrderResult() { AmountCalculated = false, CalculatedAmount = 0, PromotionApplied = false, IsComboItemsPromotion = true };

            //Act
            CartOrderResult actualCartOrderResult = _promotionCategoryService.CalculatePriceForPromotionCategory(new List<ICartOrderService> { _cartOrders[2] });

            //Assert
            Assert.NotNull(actualCartOrderResult);
            Assert.Equal(expectedCartOrderResult.CalculatedAmount, actualCartOrderResult.CalculatedAmount);
            Assert.Equal(expectedCartOrderResult.AmountCalculated, actualCartOrderResult.AmountCalculated);
            Assert.Equal(expectedCartOrderResult.PromotionApplied, actualCartOrderResult.PromotionApplied);
            Assert.Equal(expectedCartOrderResult.IsComboItemsPromotion, actualCartOrderResult.IsComboItemsPromotion);
        }


        [Theory]
        [ClassData(typeof(SKUCAndSKUDTestData))]
        public void ShouldReturnCardOrderResultObjectForSKUCAndSKUDWithAppliedPromotion(List<ICartOrderService> cartOrders, CartOrderResult expectedCartOrderResult)
        {
            //Act
            CartOrderResult actualCartOrderResult = _promotionCategoryService.CalculatePriceForPromotionCategory(cartOrders);

            //Assert
            Assert.NotNull(actualCartOrderResult);
            Assert.Equal(expectedCartOrderResult.CalculatedAmount, actualCartOrderResult.CalculatedAmount);
            Assert.Equal(expectedCartOrderResult.AmountCalculated, actualCartOrderResult.AmountCalculated);
            Assert.Equal(expectedCartOrderResult.PromotionApplied, actualCartOrderResult.PromotionApplied);
            Assert.Equal(expectedCartOrderResult.IsComboItemsPromotion, actualCartOrderResult.IsComboItemsPromotion);
        }


        [Fact]
        public void ShouldReturnCardOrderResultObjectForSKUBWithOutApplyingPromotion()
        {
            //Arrange
            _promotionService.AddSKUToAppliedPromotions(new List<SKU> { SKU.B });
            CartOrderResult expectedCartOrderResult = new CartOrderResult() { AmountCalculated = true, CalculatedAmount = 150, PromotionApplied = false, IsComboItemsPromotion = false };

            //Act
            CartOrderResult actualCartOrderResult = _promotionCategoryService.CalculatePriceForPromotionCategory(new List<ICartOrderService> { new SKUACartOrderService { SKU = SKU.B, UnitPrice = 30, Quantity = 5 } });

            //Assert
            Assert.NotNull(actualCartOrderResult);
            Assert.Equal(expectedCartOrderResult.CalculatedAmount, actualCartOrderResult.CalculatedAmount);
            Assert.Equal(expectedCartOrderResult.AmountCalculated, actualCartOrderResult.AmountCalculated);
            Assert.Equal(expectedCartOrderResult.PromotionApplied, actualCartOrderResult.PromotionApplied);
            Assert.Equal(expectedCartOrderResult.IsComboItemsPromotion, actualCartOrderResult.IsComboItemsPromotion);
        }
    }
}


public class SKUCAndSKUDTestData : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[] {new List<ICartOrderService> { new SKUCCartOrderService { SKU = SKU.C, UnitPrice = 20, Quantity = 1, IgnoreComboPromotion = true }, new SKUDCartOrderService { SKU = SKU.D, UnitPrice = 15, Quantity = 1, IgnoreComboPromotion = true } },
        new CartOrderResult() { AmountCalculated = true, CalculatedAmount = 30, PromotionApplied = true, IsComboItemsPromotion = false }},
        new object[] {new List<ICartOrderService> { new SKUCCartOrderService { SKU = SKU.C, UnitPrice = 20, Quantity = 2, IgnoreComboPromotion = true }, new SKUDCartOrderService { SKU = SKU.D, UnitPrice = 15, Quantity = 2, IgnoreComboPromotion = true } },
        new CartOrderResult() { AmountCalculated = true, CalculatedAmount = 60, PromotionApplied = true, IsComboItemsPromotion = false } },
        new object[] {new List<ICartOrderService> { new SKUCCartOrderService { SKU = SKU.C, UnitPrice = 20, Quantity = 2, IgnoreComboPromotion = true }, new SKUDCartOrderService { SKU = SKU.D, UnitPrice = 15, Quantity = 4, IgnoreComboPromotion = true } },
        new CartOrderResult() { AmountCalculated = true, CalculatedAmount = 90, PromotionApplied = true, IsComboItemsPromotion = false } }
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}