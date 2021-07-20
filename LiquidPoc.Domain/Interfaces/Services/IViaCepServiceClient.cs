using LiquidPoc.Domain.Entities;
using System.Threading.Tasks;

namespace LiquidPoc.Domain.Interfaces.Services
{
    public interface IViaCepServiceClient
    {
        public Task<AddressEntity> SearchAddressByZipCode(string cep);
    }
}
