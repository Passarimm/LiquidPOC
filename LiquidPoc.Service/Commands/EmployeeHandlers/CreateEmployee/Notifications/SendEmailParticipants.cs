using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace LiquidPoc.Service.Commands.EmployeeHandlers.CreateEmployee.Notifications
{
    public class SendEmailParticipants : INotificationHandler<CreateEmployeeNotification>
    {
        public async Task Handle(CreateEmployeeNotification notification, CancellationToken cancellationToken)
        {
             Debug.WriteLine("Enviar email para participantes do: " + notification.Employee.Name);
        }
    }
}
