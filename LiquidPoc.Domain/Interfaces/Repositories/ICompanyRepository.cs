using LiquidPoc.Domain.Entities;
using System;

namespace LiquidPoc.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository : _IBaseRepository<CompanyEntity, Guid>
    {
    }
}
