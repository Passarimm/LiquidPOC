using LiquidPoc.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Service.Commands.EmployeeHandlers.UpdateEmployee
{ 
    public class UpdateEmployeeRequest : IRequest<Response>
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public DateTime BirthDate { get; init; }
        public MaritalStatus MaritalStatus { get; init; }
        public Guid CompanyId { get; init; }
    }
}
