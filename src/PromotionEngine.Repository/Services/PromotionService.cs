using PromotionEngine.Domain.Dtos;
using PromotionEngine.Domain.Models;
using PromotionEngine.IRepository.IServices;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Repository.Services
{
    public class PromotionService : IPromotionService
    {
        public IEnumerable<Promotion> GetActivePromotions()
        {
            return new PromotionDto().Promotions.Where(e => e.IsActive == true).ToList();
        }
    }
}
