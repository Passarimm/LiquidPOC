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

namespace LiquidPoc.Service.Commands.EmployeeHandlers.UpdateEmployee
{
    public class UpdateEmployeeHandler : RequestHandlerBase, IRequestHandler<UpdateEmployeeRequest, Response>
    {
        private ILightConfiguration<CustomSettings> _configuration;
        private CustomSettings _customSettings;
        protected readonly ILogger<UpdateEmployeeHandler> _logger;
        private IEmployeeRepository _repository;
        public UpdateEmployeeHandler(IMediator mediatorService
            , ILightContext contextService
            , ILightTelemetry telemetryService
            , IMapper mapperService
            , ILightConfiguration<CustomSettings> configuration
            , IOptions<CustomSettings> customSettings
            , IEmployeeRepository repository
            , ILogger<UpdateEmployeeHandler> logger = null)
            : base(mediatorService, contextService, telemetryService, mapperService)
        {
            _configuration = configuration;
            _logger = logger;
            _customSettings = customSettings.Value;
            _repository = repository;
        }

        public async Task<Response> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var assembly = _repository.GetById(request.Id);

            //assembly.Name = request.Name;
            //assembly.Description = request.Description;
            //assembly.StartDate = request.StartDate;
            //assembly.EndDate = request.EndDate;
            //assembly.UpdatedAt = DateTime.Now;
            //assembly = _repository.Update(assembly);

            return new Response(assembly, true);
        }
    }
}
