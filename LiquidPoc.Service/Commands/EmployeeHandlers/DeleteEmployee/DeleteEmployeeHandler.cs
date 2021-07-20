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

namespace LiquidPoc.Service.Commands.EmployeeHandlers.DeleteEmployee
{
    public class DeleteEmployeeHandler : RequestHandlerBase, IRequestHandler<DeleteEmployeeRequest, Response>
    {
        private ILightConfiguration<CustomSettings> _configuration;
        private CustomSettings _customSettings;
        protected readonly ILogger<DeleteEmployeeHandler> _logger;
        private IEmployeeRepository _repository;
        public DeleteEmployeeHandler(IMediator mediatorService
            , ILightContext contextService
            , ILightTelemetry telemetryService
            , IMapper mapperService
            , ILightConfiguration<CustomSettings> configuration
            , IOptions<CustomSettings> customSettings
            , IEmployeeRepository repository
            , ILogger<DeleteEmployeeHandler> logger = null)
            : base(mediatorService, contextService, telemetryService, mapperService)
        {
            _configuration = configuration;
            _logger = logger;
            _customSettings = customSettings.Value;
            _repository = repository;
        }

        public async Task<Response> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            _repository.Delete(new EmployeeEntity() {Id = request.Id });

            return new Response($"Assembly {request.Id} deleted.", true);

        }
    }
}
