using LiquidPoc.Domain.Entities;
using MediatR;

namespace LiquidPoc.Service.Commands.CompanyHandlers.CreateCompany.Notifications
{
    public class CreateCompanyNotification : INotification
    {
        public CompanyEntity Company { get; init; }
        public CreateCompanyNotification(CompanyEntity company)
        {
            Company = company;
        }
    }
}
