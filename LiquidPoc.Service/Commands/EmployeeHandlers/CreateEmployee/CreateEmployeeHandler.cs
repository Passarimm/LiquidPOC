using LiquidPoc.Domain.Entities;
using LiquidPoc.Domain.Interfaces.Repositories;
using LiquidPoc.Infra.CrossCutting.ConfigurationSettings;
using AutoMapper;
using FluentValidation;
using Liquid.Core.Configuration;
using Liquid.Core.Context;
using Liquid.Core.Telemetry;
using Liquid.Domain;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
namespace LiquidPoc.Service.Commands.EmployeeHandlers.CreateEmployee
{
    public class CreateEmployeeHandler : RequestHandlerBase, IRequestHandler<CreateEmployeeRequest, Response>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private ILightConfiguration<CustomSettings> _configuration;
        private IMediator _mediatorService;
        private ILightContext _context;
        private CustomSettings _customSettings;
        protected readonly ILogger<CreateEmployeeHandler> _logger;
        private IEmployeeRepository _repository;
        public CreateEmployeeHandler(IMediator mediatorService
            , ILightContext contextService
            , ILightTelemetry telemetryService
            , IMapper mapperService
            , ILightConfiguration<CustomSettings> configuration
            , IOptions<CustomSettings> customSettings
            , IEmployeeRepository repository
            , IStringLocalizer<SharedResources> localizer
            , ILogger<CreateEmployeeHandler> logger = null
            )
            : base(mediatorService, contextService, telemetryService, mapperService)
        {

            _configuration = configuration;
            _logger = logger;
            _customSettings = customSettings.Value;
            _repository = repository;
            _context = contextService;
            _mediatorService = mediatorService;
            _localizer = localizer;
        }

        public async Task<Response> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {

            var assembly = new EmployeeEntity()
            {
                Id = new Guid(),
                Name = request.Name,
                BirthDate = request.BirthDate,
                MaritalStatus = request.MaritalStatus,
                CreateAt = DateTime.Now,
                Active = true
            };

            AssemblyEntityValidator validator = new AssemblyEntityValidator();
            validator.ValidateAndThrow(assembly);

            _context.Notify("teste1", _localizer["Hello World!"]);

            assembly = await _repository.CreateAsync(assembly);

            var assemblyNotification = new CreateEmployeeNotification(assembly);

            _ = _mediatorService.Publish(assemblyNotification);

            return new Response(assembly);
        }
    }
}
