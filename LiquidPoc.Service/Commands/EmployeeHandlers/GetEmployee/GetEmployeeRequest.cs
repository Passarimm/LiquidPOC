using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace LiquidPoc.Service.Commands.EmployeeHandlers.GetEmployee
{
    public class GetEmployeeRequest : IRequest<Response>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}
