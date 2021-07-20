using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace LiquidPoc.Service.Commands.EmployeeHandlers.CreateEmployee.Notifications
{
    public class CreateUsers : INotificationHandler<CreateEmployeeNotification>
    {
        public async Task Handle(CreateEmployeeNotification notification, CancellationToken cancellationToken)
        {
             Debug.WriteLine("Criar Usuários: " + notification.Employee.Name);
        }
    }
}
