using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.IRepository.IServices;
using PromotionEngine.Repository.Services;

namespace PromotionEngine.Repository.UnitTests
{
    /// <summary>
    /// Start up class for dependency injection
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// register services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IPromotionEngineService, PromotionEngineService>();
            services.AddScoped<IPromotionCategoryService, PromotionCategoryService>();
        }
    }
}
