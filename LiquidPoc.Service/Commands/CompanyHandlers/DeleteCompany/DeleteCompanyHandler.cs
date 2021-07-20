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

namespace LiquidPoc.Service.Commands.CompanyHandlers.DeleteCompany
{
    public class DeleteCompanyHandler : RequestHandlerBase, IRequestHandler<DeleteCompanyRequest, Response>
    {
        private ILightConfiguration<CustomSettings> _configuration;
        private ILightContext _context;
        private CustomSettings _customSettings;
        protected readonly ILogger<DeleteCompanyHandler> _logger;
        //private ILightCache _cache;
        private ICompanyRepository _repository;
        public DeleteCompanyHandler(IMediator mediatorService
            , ILightContext contextService
            , ILightTelemetry telemetryService
            , IMapper mapperService
            , ILightConfiguration<CustomSettings> configuration
            , IOptions<CustomSettings> customSettings
            , ICompanyRepository repository
            , ILogger<DeleteCompanyHandler> logger = null)
            : base(mediatorService, contextService, telemetryService, mapperService)
        {
            _configuration = configuration;
            _logger = logger;
            _customSettings = customSettings.Value;
            _repository = repository;
            _context = contextService;
        }

        public async Task<Response> Handle(DeleteCompanyRequest request, CancellationToken cancellationToken)
        {
            _repository.Delete(new CompanyEntity() { Id = request.Id });

            return new Response($"Company {request.Id} deleted.", true);
        }
    }
}
