using AutoMapper;
using FluentValidation;
using Liquid.Core.Configuration;
using Liquid.Core.Context;
using Liquid.Core.Telemetry;
using Liquid.Domain;
using Liquid.Messaging;
using LiquidPoc.Domain.Entities;
using LiquidPoc.Domain.Interfaces.Repositories;
using LiquidPoc.Infra.CrossCutting.ConfigurationSettings;
using LiquidPoc.Service.Commands.CompanyHandlers.CreateCompany.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LiquidPoc.Service.Commands.CompanyHandlers.CreateCompany
{
    public class CreateCompanyHandler : RequestHandlerBase, IRequestHandler<CreateCompanyRequest, Response>
    {
        private IMediator _mediatorService;
        private ICompanyRepository _repository;


        private ILightConfiguration<CustomSettings> _configuration;
        private ILightContext _context;
        private CustomSettings _customSettings;
        protected readonly ILogger<CreateCompanyHandler> _logger;
        //private ILightProducer<CreateCompanyMessage> _producer;
        private readonly ILightProducer<CreateCompanyMessage> _producer;
        public CreateCompanyHandler(IMediator mediatorService
            , ILightContext contextService
            , ILightTelemetry telemetryService
            , IMapper mapperService
            

            , ILightConfiguration<CustomSettings> configuration
            , IOptions<CustomSettings> customSettings
            , ICompanyRepository repository

            , ILightProducer<CreateCompanyMessage> producer
            , ILogger<CreateCompanyHandler> logger = null)
            : base(mediatorService, contextService, telemetryService, mapperService)
        {
            _mediatorService = mediatorService;
            _repository = repository;
            _producer = producer;

            _configuration = configuration;
            _logger = logger;
            _customSettings = customSettings.Value;
            _context = contextService;
        }

        public async Task<Response> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = new CompanyEntity()
            {
                Id = new Guid(),
                Name = request.Name,
                CreateAt = DateTime.Now,
                Active = true
            };

            CompanyEntityValidator validator = new CompanyEntityValidator();
            validator.ValidateAndThrow(company);

            company = await _repository.CreateAsync(company);

            var notifications = new CreateCompanyNotification(company);
            await _mediatorService.Publish(notifications, cancellationToken);

            return new Response(company, true);

        }
    }
}
