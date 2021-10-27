using PromotionEngine.Domain.Enums;
using PromotionEngine.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Domain.Dtos
{
    /// <summary>
    /// Cart orders Dto
    /// </summary>
    public class CartOrderDto
    {
        /// <summary>
        /// cart orders items
        /// </summary>
        private readonly List<CartItem> cartItems;

        public CartOrderDto(int scenario)
        {
            IEnumerable<SKU_UnitPrice> skuList = (new SKU_UnitPriceDto()).SkuUnitPrice;
            decimal SKU_A_UP = skuList.Where(e => e.SKU == SKU.A).Select(k => k.UnitPrice).FirstOrDefault();
            decimal SKU_B_UP = skuList.Where(e => e.SKU == SKU.B).Select(k => k.UnitPrice).FirstOrDefault();
            decimal SKU_C_UP = skuList.Where(e => e.SKU == SKU.C).Select(k => k.UnitPrice).FirstOrDefault();
            decimal SKU_D_UP = skuList.Where(e => e.SKU == SKU.D).Select(k => k.UnitPrice).FirstOrDefault();

            cartItems = scenario switch
            {
                1 => new List<CartItem>() { new CartItem() { Quantity = 1, SKU = SKU.A, UnitPrice = SKU_A_UP }, new CartItem() { Quantity = 1, SKU = SKU.B, UnitPrice = SKU_B_UP }, new CartItem() { Quantity = 1, SKU = SKU.C, UnitPrice = SKU_C_UP } },
                2 => new List<CartItem>() { new CartItem() { Quantity = 5, SKU = SKU.A, UnitPrice = SKU_A_UP }, new CartItem() { Quantity = 5, SKU = SKU.B, UnitPrice = SKU_B_UP }, new CartItem() { Quantity = 1, SKU = SKU.C, UnitPrice = SKU_C_UP } },
                3 => new List<CartItem>() { new CartItem() { Quantity = 3, SKU = SKU.A, UnitPrice = SKU_A_UP }, new CartItem() { Quantity = 5, SKU = SKU.B, UnitPrice = SKU_B_UP }, new CartItem() { Quantity = 1, SKU = SKU.C, UnitPrice = SKU_C_UP }, new CartItem() { Quantity = 1, SKU = SKU.D, UnitPrice = SKU_D_UP } },
                _ => new List<CartItem>()
            };
        }

        /// <summary>
        /// return cart orders list based on selection
        /// </summary>
        public List<CartItem> CartOrders { get => this.cartItems; }
    }
}
