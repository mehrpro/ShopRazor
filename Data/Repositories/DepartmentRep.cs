using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class DepartmentRep : Repository<Department> , IDepartmentRep
    {
        public DepartmentRep(ShopDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Department>> GetAllWithCompanyAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Department> GetWithCompanyIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Department>> GetAllWithCompanyBYCompanyIdAsync(int companyId)
        {
            throw new System.NotImplementedException();
        }

        private ShopDbContext ShopDbContext
        {
            get { return Context as ShopDbContext; }
        }
    }
}