using AutoMapper;
using Liquid.Core.Configuration;
using Liquid.Core.Context;
using Liquid.Core.Telemetry;

using LiquidPoc.Domain.Entities;
using LiquidPoc.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LiquidPoc.Service.Commands.AddressHandlers.SearchByZipCode
{
    public class ViaCepServiceClient2
    {

    }
        //public class ViaCepServiceClient2 : LightHttpService, IViaCepServiceClient
        //{
        //    public ViaCepServiceClient2(IHttpClientFactory httpClientFactory,
        //                       ILoggerFactory loggerFactory,
        //                       ILightContextFactory contextFactory,
        //                       ILightTelemetryFactory telemetryFactory,
        //                       ILightConfiguration<List<LightServiceSetting>> servicesSettings,
        //                       IMapper mapperService)
        //        : base(httpClientFactory,
        //              loggerFactory,
        //              contextFactory,
        //              telemetryFactory,
        //              servicesSettings,
        //              mapperService)
        //    {

        //    }

        //    public async Task<AddressEntity> SearchAddressByZipCode(string cep)
        //    {
        //        var httpResponse = await GetAsync<SearchByZipCodeResponse>($"{cep}/json");

        //        if (httpResponse.HttpResponse.IsSuccessStatusCode)
        //        {
        //            var result = await httpResponse.GetContentObjectAsync();
        //            return new AddressEntity()
        //            {
        //                ZipCode = result.cep,
        //                LineOne = result.logradouro,
        //                LineTwo = result.complemento,
        //                Neighborhood = result.bairro,
        //                City = result.localidade,
        //                District = result.uf,
        //                Country = "Brazil"
        //            };
        //        }

        //        // process the status code and throw exceptions if needed.
        //        return null;
        //    }
        //}
    }
