using Microsoft.Extensions.Options;
using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using System.Collections.Generic;

namespace PromotionEngine.Domain.Dtos
{
    /// <summary>
    /// SKU Unit Price Dto
    /// </summary>
    public class SKU_UnitPriceDto
    {
        /// <summary>
        /// SKU unit prices
        /// </summary>
        private List<SKU_UnitPrice> _skuUnitPrice;

        public SKU_UnitPriceDto()
        {
            _skuUnitPrice = new List<SKU_UnitPrice>
            {
                new SKU_UnitPrice { SKU = SKU.A, UnitPrice=50 },
                new SKU_UnitPrice { SKU = SKU.B, UnitPrice=30 },
                new SKU_UnitPrice { SKU = SKU.C, UnitPrice=20 },
                new SKU_UnitPrice { SKU = SKU.D, UnitPrice=15 }
            };
        }

        /// <summary>
        /// SKU unit prices
        /// </summary>
        public IEnumerable<SKU_UnitPrice> SkuUnitPrice { get => this._skuUnitPrice; }
    }
}
