using PromotionEngine.IRepository.IServices;

namespace PromotionEngine.Repository.Services
{
    /// <summary>
    /// SKU C Cart Order Service
    /// </summary>
    public class SKUCCartOrderService : BaseCartOrderService
    {

        public SKUCCartOrderService(IPromotionCategoryService promotionCategoryService) : base(promotionCategoryService)
        {
        }

        public SKUCCartOrderService() { }
    }
}
