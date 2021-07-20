using Liquid.Services.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LiquidPoc.Infra.ServiceClient.DI
{
    public static class RegisterHttpServices
    {
        public static IServiceCollection RegisterHttpService(this IServiceCollection services)
        {
            services.AddHttpServices(typeof(RegisterHttpServices).Assembly);

            return services;
        }
    }
}
