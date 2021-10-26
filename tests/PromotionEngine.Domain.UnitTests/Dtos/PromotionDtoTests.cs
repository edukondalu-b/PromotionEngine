using PromotionEngine.Domain.Dtos;
using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PromotionEngine.Domain.UnitTests.Dtos
{
    public class PromotionDtoTests
    {
        private readonly PromotionDto _promotionDto;

        private readonly List<SKU> _expectedSkus;

        private readonly List<string> randomGuids = new List<string> { "c3253f17-83b3-41b4-8669-33cc6a09459f", "54b129d9-f118-4bd7-be24-4dcca2fec631", "8c87b0b5-aae6-4e2c-9c6d-a22b34dff592" };

        public PromotionDtoTests()
        {
            _promotionDto = new PromotionDto();

            _expectedSkus = new List<SKU> { SKU.A, SKU.B, SKU.C, SKU.D };
        }

        [Fact]
        public void ShouldReturnThreePromotionsCount()
        {
            //Act
            int unitPricesCount = _promotionDto.Promotions.Count();

            //Assert
            Assert.True(unitPricesCount > 0);
            Assert.Equal(3, unitPricesCount);
        }

        [Fact]
        public void ShouldContainAllSKUsInPromotions()
        {
            //Act
            IEnumerable<Promotion> promotions = _promotionDto.Promotions;

            //Assert
            Assert.NotNull(promotions);
            Assert.Equal(_expectedSkus, promotions.SelectMany(e => e.PromotionSKUId).ToList());
        }

        [Fact]
        public void ShouldContainValidPromotionNameAndSKU_A_Item()
        {
            //Act
            Promotion promotionForSkuA = _promotionDto.Promotions.Where(e => e.Id == Guid.Parse(randomGuids[0])).FirstOrDefault();

            //Assert
            Assert.NotNull(promotionForSkuA);
            Assert.True(promotionForSkuA.PromotionName == "3 A's For 130");
            Assert.Equal(new List<SKU> { SKU.A }, promotionForSkuA.PromotionSKUId.ToList());
        }

        [Fact]
        public void ShouldContainValidPromotionNameAndSKU_B_Item()
        {
            //Act
            Promotion promotionForSkuB = _promotionDto.Promotions.Where(e => e.Id == Guid.Parse(randomGuids[1])).FirstOrDefault();

            //Assert
            Assert.NotNull(promotionForSkuB);
            Assert.True(promotionForSkuB.PromotionName == "2 B's For 45");
            Assert.Equal(new List<SKU> { SKU.B }, promotionForSkuB.PromotionSKUId.ToList());
        }

        [Fact]
        public void ShouldContainValidPromotionNameAndSKU_C_And_D_Item()
        {
            //Act
            Promotion promotionForSku = _promotionDto.Promotions.Where(e => e.Id == Guid.Parse(randomGuids[2])).FirstOrDefault();

            //Assert
            Assert.NotNull(promotionForSku);
            Assert.True(promotionForSku.PromotionName == "C & D For 30");
            Assert.Equal(new List<SKU> { SKU.C, SKU.D }, promotionForSku.PromotionSKUId.ToList());
        }
    }
}
