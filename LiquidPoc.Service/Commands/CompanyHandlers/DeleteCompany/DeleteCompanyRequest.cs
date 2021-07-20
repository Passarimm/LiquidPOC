using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Service.Commands.CompanyHandlers.DeleteCompany
{
    public class DeleteCompanyRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
