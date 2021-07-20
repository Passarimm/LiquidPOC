using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace LiquidPoc.Service.Commands.CompanyHandlers.GetCompany
{
    public class GetCompanyRequest : IRequest<Response>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}
