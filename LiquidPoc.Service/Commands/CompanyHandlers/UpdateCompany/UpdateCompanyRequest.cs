using MediatR;
using System;

namespace LiquidPoc.Service.Commands.CompanyHandlers.UpdateCompany
{
    public class UpdateCompanyRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
