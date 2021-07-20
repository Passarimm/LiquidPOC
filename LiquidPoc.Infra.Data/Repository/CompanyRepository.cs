using LiquidPoc.Domain.Entities;
using LiquidPoc.Domain.Interfaces.Repositories;
using LiquidPoc.Infra.Data.Base;
using System;

namespace LiquidPoc.Infra.Data.Repository
{
    public class CompanyRepository : RepositoryBase<CompanyEntity, Guid>, ICompanyRepository
    {
        private readonly DataContext _context;
        public CompanyRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
