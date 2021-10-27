using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PromotionEngine.DI.DependencyInjection;
using PromotionEngine.IRepository.IServices;
using System;

namespace PromotionEngine.ConsoleUI
{
    /// <summary>
    /// Start up class
    /// </summary>
    class Startup
    {
        private static IServiceCollection _serviceCollection { get; set; }

        public Startup(string[] args)
        {
            CreateHostBuilder(args).Build();
            var serviceProvider = _serviceCollection.BuildServiceProvider();

            ICartCheckoutService _cartOrderCheckout = serviceProvider.GetService<ICartCheckoutService>();

            Console.Write("Enter scenario number(from 1 - 3): ");
            string scenario = Console.ReadLine();
            int cartOrderScenario = 0;
            bool result = int.TryParse(scenario, out cartOrderScenario);
            decimal returnVal = _cartOrderCheckout.CheckoutCartOrdersAndCalculateTotalAmount(result ? cartOrderScenario : 0);
            string consoleMsg = cartOrderScenario switch
            {
                1 => "Scenario A",
                2 => "Scenario B",
                3 => "Scenario C",
                _ => "Please enter a valid selection between 1 to 3"
            };
            Console.WriteLine(consoleMsg);
            Console.WriteLine("Total order value calculated: " + returnVal);
            Console.ReadLine();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                _serviceCollection = services;
                IConfiguration configuration = hostContext.Configuration;
                services.AddPromotionEngineService();
                services.AddPromotionCategoryService();
                services.AddPromotionService();
                services.AddCartCheckoutService();
            });
    }
}
