using LiquidPoc.Application.Controllers.Base;
using LiquidPoc.Infra.Data.Transactions;
using LiquidPoc.Service.Commands.EmployeeHandlers.CreateEmployee;
using LiquidPoc.Service.Commands.EmployeeHandlers.DeleteEmployee;
using LiquidPoc.Service.Commands.EmployeeHandlers.GetEmployee;
using LiquidPoc.Service.Commands.EmployeeHandlers.UpdateEmployee;
using Liquid.Core.Context;
using Liquid.Core.Localization;
using Liquid.Core.Telemetry;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LiquidPoc.Application.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeController : CustomControllerBase
    {
        public EmployeeController(ILoggerFactory loggerFactory, IMediator mediator, ILightContext context, ILightTelemetry telemetry, ILocalization localization, IUnitOfWork unitOfWork)
            : base(loggerFactory, mediator, context, telemetry, localization, unitOfWork)
        {

        }

        [HttpGet()]
        public async Task<IActionResult> GetEmployees([FromQuery(Name = "name")] string nameSearch) => await ExecuteAsync(new GetEmployeeRequest() { Name = nameSearch });

        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetEmployee(Guid id) => await ExecuteAsync(new GetEmployeeRequest() { Id = id });


        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeRequest request) => await ExecuteAsync(request);

        [HttpDelete(template: "{id}")]
        public async Task<IActionResult> Delete(Guid id) => await ExecuteAsync(new DeleteEmployeeRequest() { Id = id });

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeRequest request) => await ExecuteAsync(request);

    }
}
