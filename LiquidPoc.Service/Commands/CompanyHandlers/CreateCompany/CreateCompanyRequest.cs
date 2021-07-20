using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Service.Commands.CompanyHandlers.CreateCompany
{
    public class CreateCompanyRequest : IRequest<Response>
    {
        public string Name { get; set; }
    }
}
