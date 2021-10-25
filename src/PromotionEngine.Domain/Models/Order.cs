using PromotionEngine.Domain.Enums;

namespace PromotionEngine.Domain.Models
{
    public class Order
    {
        public SKU SKU { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}