using LiquidPoc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : _IBaseRepository<EmployeeEntity, Guid>
    {

    }
}
