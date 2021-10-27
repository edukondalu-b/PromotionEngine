using PromotionEngine.Domain.Dtos;
using PromotionEngine.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Domain.UnitTests.Dtos
{
    public class CartOrderDtoTests
    {
        private static CartOrderDto _cartOrderDto;

        public CartOrderDtoTests()
        {
        }

        [Fact]
        public void ShouldReturnValidCartOrderItems()
        {
            // Arrange
            _cartOrderDto = new CartOrderDto(1);

            //Act
            List<CartItem> cartItems = _cartOrderDto.CartOrders;

            //Assert
            Assert.True(cartItems.Count > 0);
            Assert.Equal(3, cartItems.Count);
        }

        [Fact]
        public void ShouldReturnEmptyCartOrderItems()
        {
            // Arrange
            _cartOrderDto = new CartOrderDto(4);

            //Act
            List<CartItem> cartItems = _cartOrderDto.CartOrders;

            //Assert
            Assert.True(cartItems.Count == 0);
        }
    }
}
