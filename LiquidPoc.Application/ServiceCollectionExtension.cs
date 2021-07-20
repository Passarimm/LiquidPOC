using Liquid.Core.Configuration;
using Liquid.Core.DependencyInjection;
using Liquid.Messaging.Azure.Extensions;
using LiquidPoc.Domain.Interfaces.Repositories;
using LiquidPoc.Domain.Models;
using LiquidPoc.Infra.CrossCutting.ConfigurationSettings;
using LiquidPoc.Infra.Data.Base;
using LiquidPoc.Infra.Data.Repository;
using LiquidPoc.Infra.Data.Transactions;
using LiquidPoc.Service.Commands.AddressHandlers.SearchByZipCode;
using LiquidPoc.Service.Commands.CompanyHandlers.CreateCompany;
using LiquidPoc.Service.Commands.CompanyHandlers.CreateCompany.Notifications;
using LiquidPoc.Service.Commands.CompanyHandlers.DeleteCompany;
using LiquidPoc.Service.Commands.CompanyHandlers.GetCompany;
using LiquidPoc.Service.Commands.CompanyHandlers.UpdateCompany;
using LiquidPoc.Service.Commands.EmployeeHandlers.CreateEmployee;
using LiquidPoc.Service.Commands.EmployeeHandlers.DeleteEmployee;
using LiquidPoc.Service.Commands.EmployeeHandlers.GetEmployee;
using LiquidPoc.Service.Commands.EmployeeHandlers.UpdateEmployee;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.Text;

namespace LiquidPoc.Application
{
    public static class ServiceCollectionExtension
    {
        private static IConfiguration _configuration;
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            _configuration = configuration;
            return services.AddTransient(typeof(ILightConfiguration<>), typeof(LightConfiguration<>));
        }

        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(CreateEmployeeRequest).GetTypeInfo().Assembly);
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            //Assembly
            services.AddAutoMapper(typeof(CreateEmployeeRequest).Assembly);
            services.AddAutoMapper(typeof(DeleteEmployeeRequest).Assembly);
            services.AddAutoMapper(typeof(GetEmployeeRequest).Assembly);
            services.AddAutoMapper(typeof(UpdateEmployeeRequest).Assembly);

            //Company
            services.AddAutoMapper(typeof(CreateCompanyRequest).Assembly);
            services.AddAutoMapper(typeof(DeleteCompanyRequest).Assembly);
            services.AddAutoMapper(typeof(GetCompanyRequest).Assembly);
            services.AddAutoMapper(typeof(UpdateCompanyRequest).Assembly);

            //Address
            services.AddAutoMapper(typeof(SearchByZipCodeRequest).Assembly);

        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<DataContext, DataContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
        }

        /// <summary>
        /// Swagger Configuration Extension
        /// </summary>
        /// <param name="services">Service object</param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {

                // SwaggerDoc configuration
                OpenApiInfo swaggerOpenApiInfoSettings = _configuration.GetSection(nameof(OpenApiInfo)).Get<OpenApiInfo>();
                c.SwaggerDoc(swaggerOpenApiInfoSettings.Version, swaggerOpenApiInfoSettings);

                // Swagger Configuration Scheme
                OpenApiSecurityScheme swaggerOpenApiSecuritySchemeSettings = _configuration.GetSection(nameof(OpenApiSecurityScheme)).Get<OpenApiSecurityScheme>();
                swaggerOpenApiSecuritySchemeSettings.In = ParameterLocation.Header;
                swaggerOpenApiSecuritySchemeSettings.Type = SecuritySchemeType.ApiKey;
                c.AddSecurityDefinition(swaggerOpenApiSecuritySchemeSettings.Scheme, swaggerOpenApiSecuritySchemeSettings);

                // Swagger Security Schema
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = swaggerOpenApiSecuritySchemeSettings.Scheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });

            });
        }

        /// <summary>
        /// Localization Extension
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureLocalization(this IServiceCollection services)
        {
            services.AddLocalization();

            services.AddMvc()
                .AddDataAnnotationsLocalization(options => {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResources));
                });
        }

        /// <summary>
        /// Messaging Extension
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureMessaging(this IServiceCollection services)
        {
            //Liquid Messaging 
            services.AddServiceBusProducer<CreateCompanyMessage>("TestAzureServiceBus", "topctest", false);

            //services.AddServiceBusConsumer<MySampleConsumer, MySampleMessage>("TestAzureServiceBus", "TestMessageTopic", "TestMessageSubscription");

        }

        /// <summary>
        /// Autentication Extension
        /// </summary>
        /// <param name="services"></param>
        public static void AddAuthentication(this IServiceCollection services)
        {

            var jwtSettings = _configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

            services.AddAuthentication(o =>
            {
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            })
            .AddCookie(IdentityConstants.ApplicationScheme);
        }


    }
}
