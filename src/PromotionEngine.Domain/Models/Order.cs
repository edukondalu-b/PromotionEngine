namespace PromotionEngine.Domain.Models
{
    public class Order
    {
        public object SKU { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}