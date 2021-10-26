using PromotionEngine.IRepository.IServices;

namespace PromotionEngine.Repository.Services
{
    /// <summary>
    /// SKU B Cart Order Service
    /// </summary>
    public class SKUBCartOrderService : BaseCartOrderService
    {
        public SKUBCartOrderService(IPromotionCategoryService promotionCategoryService) : base(promotionCategoryService)
        {
        }

        public SKUBCartOrderService() { }
    }
}
