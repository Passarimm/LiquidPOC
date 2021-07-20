using LiquidPoc.Application.Controllers.Base;
using LiquidPoc.Infra.Data.Transactions;
using LiquidPoc.Service.Commands.CompanyHandlers.CreateCompany;
using LiquidPoc.Service.Commands.CompanyHandlers.DeleteCompany;
using LiquidPoc.Service.Commands.CompanyHandlers.GetCompany;
using LiquidPoc.Service.Commands.CompanyHandlers.UpdateCompany;
using Liquid.Core.Context;
using Liquid.Core.Localization;
using Liquid.Core.Telemetry;
using Liquid.WebApi.Http.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using LiquidPoc.Service.Commands.AddressHandlers.SearchByZipCode;

namespace LiquidPoc.Application.Controllers
{
    public class AddressController : CustomControllerBase
    {
        public AddressController(ILoggerFactory loggerFactory, IMediator mediator, ILightContext context, ILightTelemetry telemetry, ILocalization localization, IUnitOfWork unitOfWork)
            : base(loggerFactory, mediator, context, telemetry, localization, unitOfWork)
        {


        }

        [HttpGet(template: "zipcode/{zipCode}")]
        public async Task<IActionResult> GetAddressByZipCode(string zipCode) => await ExecuteAsync(new SearchByZipCodeRequest(zipCode));

        //[HttpGet(template: "{id}")]
        //public async Task<IActionResult> GetCompany(Guid id) => await ExecuteAsync(new GetCompanyRequest() { Id = id });


        //[HttpPost()]
        //public async Task<IActionResult> Post([FromBody] CreateCompanyRequest request) => await ExecuteAsync(request);

        //[HttpDelete(template: "{id}")]
        //public async Task<IActionResult> Delete(Guid id) => await ExecuteAsync(new DeleteCompanyRequest() { Id = id });

        //[HttpPut()]
        //public async Task<IActionResult> Update([FromBody] UpdateCompanyRequest request) => await ExecuteAsync(request);

    }
}
