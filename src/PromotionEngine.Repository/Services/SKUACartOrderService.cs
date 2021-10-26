using PromotionEngine.IRepository.IServices;

namespace PromotionEngine.Repository.Services
{
    /// <summary>
    /// SKU A Cart Order Service
    /// </summary>
    public class SKUACartOrderService : BaseCartOrderService
    {

        public SKUACartOrderService(IPromotionCategoryService promotionCategoryService) : base(promotionCategoryService)
        {
        }

        public SKUACartOrderService() { }
    }
}
