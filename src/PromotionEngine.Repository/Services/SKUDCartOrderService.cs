using PromotionEngine.IRepository.IServices;

namespace PromotionEngine.Repository.Services
{
    /// <summary>
    /// SKU D Cart Order Service
    /// </summary>
    public class SKUDCartOrderService : BaseCartOrderService
    {
        public SKUDCartOrderService(IPromotionCategoryService promotionCategoryService) : base(promotionCategoryService)
        {
        }

        public SKUDCartOrderService() { }
    }
}
