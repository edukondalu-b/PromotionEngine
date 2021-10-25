using PromotionEngine.Domain.Models;
using System.Collections.Generic;

namespace PromotionEngine.IRepository.IServices
{
    public interface IPromotionService
    {
        IEnumerable<Promotion> GetActivePromotions();
    }
}
