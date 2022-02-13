using System.Collections.Generic;
using System.Linq;
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
            return await ShopDbContext.Departments.Include(x=>x.Company).ToListAsync();
        }

        public async Task<Department> GetWithCompanyByDepartmentIdAsync(int departmentId)
        {
            return await ShopDbContext.Departments.Include(x=>x.Company).SingleOrDefaultAsync(x=>x.DepartmentID == departmentId);
        }

        public async Task<IEnumerable<Department>> GetAllWithCompanyBYCompanyIdAsync(int companyId)
        {
            return await ShopDbContext.Departments.Include(x=>x.Company).Where(x=>x.CompanyID_FK == companyId).ToListAsync();   
        }

        private ShopDbContext ShopDbContext
        {
            get { return Context as ShopDbContext; }
        }
    }
}