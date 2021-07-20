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
using System.Threading;
using System.Threading.Tasks;
using System;

namespace LiquidPoc.Service.Commands.EmployeeHandlers.GetEmployee
{
    public class GetEmployeeHandler : RequestHandlerBase, IRequestHandler<GetEmployeeRequest, Response>
    {
        private ILightConfiguration<CustomSettings> _configuration;
        private CustomSettings _customSettings;
        protected readonly ILogger<GetEmployeeHandler> _logger;
        private IEmployeeRepository _repository;
        public GetEmployeeHandler(IMediator mediatorService
            , ILightContext contextService
            , ILightTelemetry telemetryService
            , IMapper mapperService
            , ILightConfiguration<CustomSettings> configuration
            , IOptions<CustomSettings> customSettings
            , IEmployeeRepository repository
            , ILogger<GetEmployeeHandler> logger = null)
            : base(mediatorService, contextService, telemetryService, mapperService)
        {
            _configuration = configuration;
            _logger = logger;
            _customSettings = customSettings.Value;
            _repository = repository;
        }

        public async Task<Response> Handle(GetEmployeeRequest request, CancellationToken cancellationToken)
        {
            if(request.Id != null)
            {
                var assembly = _repository.GetById(request.Id.Value);
                return new Response(assembly, true);
            }
            else
            {
                if(request.Name != null)
                {
                    var assemblies = _repository.ListBy(x => x.Name == request.Name);
                    return new Response(assemblies, true);
                }
                else
                {
                    var assemblies = _repository.List();
                    return new Response(assemblies, true);
                }
            }
        }
    }
}
