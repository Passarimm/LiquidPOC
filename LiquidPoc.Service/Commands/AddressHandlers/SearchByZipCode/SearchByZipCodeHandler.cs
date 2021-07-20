using AutoMapper;
using Liquid.Core.Context;
using Liquid.Core.Telemetry;
using Liquid.Domain;
using LiquidPoc.Domain.Interfaces.Services;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LiquidPoc.Service.Commands.AddressHandlers.SearchByZipCode
{
    public class SearchByZipCodeHandler : RequestHandlerBase, IRequestHandler<SearchByZipCodeRequest, Response>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        protected readonly ILogger<SearchByZipCodeHandler> _logger;
        private readonly IViaCepServiceClient _movieService;

        public SearchByZipCodeHandler(IMediator mediatorService
                                    , ILightContext contextService
                                    , ILightTelemetry telemetryService
                                    , IMapper mapperService
                                    , IViaCepServiceClient movieService
                                    , IStringLocalizer<SharedResources> localizer
                                    , ILogger<SearchByZipCodeHandler> logger = null
            )
            : base(mediatorService, contextService, telemetryService, mapperService)
        {
            _movieService = movieService;
            _logger = logger;
            _localizer = localizer;
        }

        public async Task<Response> Handle(SearchByZipCodeRequest request, CancellationToken cancellationToken)
        {
            var result = await _movieService.SearchAddressByZipCode(request.ZipCode);

            return new Response(result, true);
        }
    }
}
