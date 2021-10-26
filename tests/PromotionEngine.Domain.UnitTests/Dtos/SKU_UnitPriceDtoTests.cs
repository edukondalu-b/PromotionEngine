using PromotionEngine.Domain.Dtos;
using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PromotionEngine.Domain.UnitTests.Dtos
{
    public class SKU_UnitPriceDtoTests
    {
        private readonly SKU_UnitPriceDto _sKU_UnitPriceDto;

        private readonly List<SKU> _expectedSkus;

        public SKU_UnitPriceDtoTests()
        {
            _sKU_UnitPriceDto = new SKU_UnitPriceDto();

            _expectedSkus = new List<SKU> { SKU.A, SKU.B, SKU.C, SKU.D };
        }

        [Fact]
        public void ShouldReturnFourSKUUnitPriceCount()
        {
            //Act
            int unitPricesCount = _sKU_UnitPriceDto.SkuUnitPrice.Count();

            //Assert
            Assert.True(unitPricesCount > 0);
            Assert.Equal(4, unitPricesCount);
        }

        [Fact]
        public void ShouldContainAllSKUsInSkuUnitPrices()
        {
            //Act
            IEnumerable<SKU_UnitPrice> skuUitPrices = _sKU_UnitPriceDto.SkuUnitPrice;

            //Assert
            Assert.NotNull(skuUitPrices);
            Assert.Equal(_expectedSkus, skuUitPrices.Select(e => e.SKU).ToList());
        }
    }
}
