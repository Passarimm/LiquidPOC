using Liquid.Domain.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Service.DI
{
    public static class DomainRequestHandlers
    {
        public static IServiceCollection RegisterDomainConfigs(this IServiceCollection services)
        {
            services.AddDomainRequestHandlers(typeof(DomainRequestHandlers).Assembly);

            return services;
        }
    }
}
