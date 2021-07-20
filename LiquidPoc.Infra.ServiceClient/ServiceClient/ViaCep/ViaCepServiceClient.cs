using AutoMapper;
using Liquid.Core.Configuration;
using Liquid.Core.Context;
using Liquid.Core.Telemetry;

using Liquid.Services.Configuration;
using Liquid.Services.Http;
using LiquidPoc.Domain.Entities;
using LiquidPoc.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LiquidPoc.Infra.ServiceClient.ServiceClient.ViaCep
{
    public class ViaCepAddressResponse
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
    }

    public class ViaCepServiceClient : LightHttpService, IViaCepServiceClient
    {
        public ViaCepServiceClient(IHttpClientFactory httpClientFactory,
                           ILoggerFactory loggerFactory,
                           ILightContextFactory contextFactory,
                           ILightTelemetryFactory telemetryFactory,
                           ILightServiceConfiguration<LightServiceSetting> serviceSettings,
                           IMapper mapperService) : 
            base(httpClientFactory, loggerFactory, contextFactory, telemetryFactory, serviceSettings, mapperService)
        {
        }

        public async Task<AddressEntity> SearchAddressByZipCode(string cep)
        {
            var httpResponse = await GetAsync<ViaCepAddressResponse>($"{cep}/json");

            if (httpResponse.HttpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.GetContentObjectAsync();
                return new AddressEntity()
                {
                    ZipCode = result.cep,
                    LineOne = result.logradouro,
                    LineTwo = result.complemento,
                    Neighborhood = result.bairro,
                    City = result.localidade,
                    District = result.uf,
                    Country = "Brazil"
                };
            }

            // process the status code and throw exceptions if needed.
            return null;
        }
    }
}
