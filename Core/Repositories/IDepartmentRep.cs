using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IDepartmentRep : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllWithCompanyAsync();
        Task<Department> GetWithCompanyIdAsync(int id);
        Task<IEnumerable<Department>> GetAllWithCompanyBYCompanyIdAsync(int companyId);
    }
}
