using LiquidPoc.Domain.Entities;
using MediatR;

namespace LiquidPoc.Service.Commands.EmployeeHandlers.CreateEmployee
{
    public class CreateEmployeeNotification : INotification
    {
        public CreateEmployeeNotification(EmployeeEntity employee)
        {
            Employee = employee;
        }

        public EmployeeEntity Employee { get; init; }
    }
}
