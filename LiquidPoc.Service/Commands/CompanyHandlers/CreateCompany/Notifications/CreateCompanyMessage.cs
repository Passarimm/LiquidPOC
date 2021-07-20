namespace LiquidPoc.Service.Commands.CompanyHandlers.CreateCompany.Notifications
{
    public class CreateCompanyMessage
    {
        public string CompanyName { get; init; }

        public CreateCompanyMessage(string companyName)
        {
            CompanyName = companyName;
        }
    }
}
