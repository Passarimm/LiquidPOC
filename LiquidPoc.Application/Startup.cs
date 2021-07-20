using Liquid.Cache.Redis;
using Liquid.Core.Context;
using Liquid.Core.Telemetry;
using Liquid.Domain.Extensions;
using Liquid.Services.Configuration;
using Liquid.WebApi.Http.Extensions;
using LiquidPoc.Domain.Interfaces.Services;
using LiquidPoc.Infra.ServiceClient.DI;
using LiquidPoc.Infra.ServiceClient.ServiceClient.ViaCep;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace LiquidPoc.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configure Telemetry
            services.AddDefaultTelemetry();

            //Configure LiquidContext
            services.AddDefaultContext();



            //Define ServiceCollectionExtension.cs class how to configure
            services.AddConfiguration(Configuration);
            //Liquid WebApi
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IViaCepServiceClient, ViaCepServiceClient>();


            services.ConfigureAutoMapper();
            services.ConfigureLiquidHttp();
            services.AddDomainRequestHandlers(GetType().Assembly);

            //Configure Messaging
            services.ConfigureMessaging();

            //Configure Cache
            services.AddLightRedisCache();

            //Configure MediatR
            services.ConfigureMediatR();

            //Configure Repositories
            services.ConfigureRepositories();


            services.RegisterHttpService();

            //Configure Swagger
            services.ConfigureSwagger();

            //Configure Localization
            services.ConfigureLocalization();

            //Configure Controllers
            services.AddControllers();

            //Configure Authentication
            services.AddAuthentication();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Liquid POC v1"));
            }

            var supportedCultures = new[] { "en-US", "pt", "es" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
