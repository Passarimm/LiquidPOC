using AutoMapper;
using Liquid.Core.Configuration;
using Liquid.Core.Context;
using Liquid.Core.Telemetry;
using Liquid.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LiquidPoc.Domain.Entities;
using LiquidPoc.Domain.Interfaces.Repositories;
using LiquidPoc.Infra.CrossCutting.ConfigurationSettings;
using System;
using System.Threading;
using System.Threading.Tasks;
using Liquid.Cache;
using LiquidPoc.Service.Exceptions;
using Liquid.Core.Exceptions;
using Microsoft.Extensions.Localization;
using System.Linq;

namespace LiquidPoc.Service.Commands.CompanyHandlers.GetCompany
{
    public class GetCompanyHandler : RequestHandlerBase, IRequestHandler<GetCompanyRequest, Response>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        protected readonly ILogger<GetCompanyHandler> _logger;
        private ILightCache _cache;
        private ICompanyRepository _repository;

        //private ILightConfiguration<CustomSettings> _configuration;
        //private ILightContext _context;
        //private CustomSettings _customSettings;

        public GetCompanyHandler(     IMediator mediatorService
                                    , ILightContext contextService
                                    , ILightTelemetry telemetryService
                                    , IMapper mapperService

                                    , IOptions<CustomSettings> customSettings
                                    , ICompanyRepository repository
                                    , ILightCache cache
                                    , IStringLocalizer<SharedResources> localizer
                                    , ILogger<GetCompanyHandler> logger = null
            )
            : base(mediatorService, contextService, telemetryService, mapperService)
        {
            //_customSettings = customSettings.Value;
            //_repository = repository;
            //_context = contextService;
            _cache = cache;
            _logger = logger;
            _localizer = localizer;
        }

        public async Task<Response> Handle(GetCompanyRequest request, CancellationToken cancellationToken)
        {
            if (request.Id != null)
            {
                //using Liquid.Cache (Redis)
                var result = await _cache.RetrieveOrAddAsync(
                   key: $"CompanyId:{request.Id}",
                   action: () =>
                   {
                       return _repository.GetById(request.Id.Value);
                   },
                   expirationDuration: TimeSpan.FromMinutes(1));

                //Not Found
                if(result == null)
                    throw new ResponseException(_localizer["Company not found"], ExceptionCustomCodes.NotFound);

                return new Response(result, true);
            }
            else //Search by name
            {
                if (request.Name != null)
                {
                    var result = _repository.ListBy(x => x.Name == request.Name);

                    //Not Found
                    if (!result.Any())
                        throw new ResponseException(_localizer["Company not found"], ExceptionCustomCodes.NotFound);

                    return new Response(result, true);
                }
                else
                {
                    throw new ResponseException(_localizer["Invalid parameters"], ExceptionCustomCodes.BadRequest);
                }
            }
        }
    }
}
