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
namespace LiquidPoc.Service.Commands.CompanyHandlers.UpdateCompany
{
    public class UpdateCompanyHandler : RequestHandlerBase, IRequestHandler<UpdateCompanyRequest, Response>
    {
        private ILightConfiguration<CustomSettings> _configuration;
        private ILightContext _context;
        private CustomSettings _customSettings;
        protected readonly ILogger<UpdateCompanyHandler> _logger;
        //private ILightCache _cache;
        private ICompanyRepository _repository;
        public UpdateCompanyHandler(IMediator mediatorService
            , ILightContext contextService
            , ILightTelemetry telemetryService
            , IMapper mapperService
            , ILightConfiguration<CustomSettings> configuration
            , IOptions<CustomSettings> customSettings
            , ICompanyRepository repository
            , ILogger<UpdateCompanyHandler> logger = null)
            : base(mediatorService, contextService, telemetryService, mapperService)
        {
            _configuration = configuration;
            _logger = logger;
            _customSettings = customSettings.Value;
            _repository = repository;
            _context = contextService;
        }

        public async Task<Response> Handle(UpdateCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = _repository.GetById(request.Id);

            //company.Name = request.Name;
            //company.UpdatedAt = DateTime.Now;
            //company = _repository.Update(company);

            return new Response(company, true);
        }
    }
}
