using MediatR;

namespace LiquidPoc.Service.Commands.AddressHandlers.SearchByZipCode
{
    public class SearchByZipCodeRequest : IRequest<Response>
    {
        public string ZipCode { get; init; }

        public SearchByZipCodeRequest(string zipCode)
        {
            ZipCode = zipCode;
        }
    }
}
