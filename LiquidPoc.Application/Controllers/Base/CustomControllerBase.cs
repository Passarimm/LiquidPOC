using LiquidPoc.Infra.Data.Transactions;
using LiquidPoc.Service.Commands;
using FluentValidation;
using Liquid.Core.Context;
using Liquid.Core.Exceptions;
using Liquid.Core.Localization;
using Liquid.Core.Telemetry;
using Liquid.Core.Utils;
using Liquid.WebApi.Http.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LiquidPoc.Application.Controllers.Base
{
    public class CustomControllerBase : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomControllerBase(ILoggerFactory loggerFactory, IMediator mediator, ILightContext context, ILightTelemetry telemetry, ILocalization localization, IUnitOfWork unitOfWork)
    : base(loggerFactory, mediator, context, telemetry, localization)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async Task<IActionResult> HandleResponseAsync<TResponse>(Func<Task<TResponse>> requestFunction, HttpStatusCode responseCode)
        {
            try
            {
                var response = await requestFunction();
                var messages = Context.GetNotifications();
                _unitOfWork.SaveChanges();
                return messages.Any() ? StatusCode((int)responseCode, new { response, messages }) : StatusCode((int)responseCode, new { response });
            }
            catch (ValidationException validationException)
            {
                return HandleValidationException(validationException);
            }
            catch (LightCustomException ex)
            {
                Telemetry.AddErrorTelemetry(ex);
                return StatusCode(ex.ResponseCode.Value, new { messages = Localization.Get(ex.Message) });
            }
        }

        /// <summary>
        /// Handles the validation exception result.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        private IActionResult HandleValidationException(ValidationException ex)
        {
            var messages = new Dictionary<string, string>();
            var index = 0;

            ex.Errors.Each(error =>
            {
                messages.Add($"{index}_{error.PropertyName}", Localization.Get(error.ErrorMessage, Context.ContextChannel));
                index++;
            });
            return StatusCode((int)HttpStatusCode.BadRequest, new { messages });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
