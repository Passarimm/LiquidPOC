using Liquid.Messaging;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LiquidPoc.Service.Commands.CompanyHandlers.CreateCompany.Notifications
{
    public class SendNotifications : INotificationHandler<CreateCompanyNotification>
    {
        private ILightProducer<CreateCompanyMessage> _producer;

        public SendNotifications(ILightProducer<CreateCompanyMessage> producer)
        {
            _producer = producer;
        }

        public async Task Handle(CreateCompanyNotification notification, CancellationToken cancellationToken)
        {
            //Exemplo de envio para tópico (service bus Azure). 
            //A configuração está no método ConfigureMessaging
            await _producer.SendMessageAsync(
                new CreateCompanyMessage(notification.Company.Name), 
                new Dictionary<string, object> { { "headerTest", "value" } });


        }
    }
}
