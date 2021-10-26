using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.IRepository.IServices;
using PromotionEngine.Repository.Services;

namespace PromotionEngine.DI.DependencyInjection
{
    /// <summary>
    /// Service collection extension for dependency injection service registration
    /// </summary>
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Add promotionCategoryService to Service collection extension
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPromotionCategoryService(this IServiceCollection services)
        {
            services.AddScoped<IPromotionCategoryService, PromotionCategoryService>();
            return services;
        }

        /// <summary>
        /// Add promotionService to Service collection extension
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPromotionService(this IServiceCollection services)
        {
            services.AddScoped<IPromotionService, PromotionService>();
            return services;
        }

        /// <summary>
        /// Add promotionEngineService to Service collection extension
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPromotionEngineService(this IServiceCollection services)
        {
            services.AddScoped<IPromotionEngineService, PromotionEngineService>();
            return services;
        }

        /// <summary>
        /// Add cartCheckoutService to Service collection extension
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCartCheckoutService(this IServiceCollection services)
        {
            services.AddScoped<ICartCheckoutService, CartCheckoutService>();
            return services;
        }
    }
}
