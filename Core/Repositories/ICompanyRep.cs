using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICompanyRep : IRepository<Company>
    {
        Task<IEnumerable<Company>> GetAllWithDepartmentAsync();
        Task<Company> GetWithDepartmentId(int id);
    }
}
