using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CompanyRep : Repository<Company>, ICompanyRep
    {
        public CompanyRep(ShopDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Company>> GetAllWithDepartmentAsync()
        {
            return await ShopDbContext.Companies.Include(x=>x.Departments).ToListAsync();
        }

        public async Task<Company> GetWithDepartmentId(int id)
        {
            return await ShopDbContext.Companies.Include(x=>x.Departments).SingleOrDefaultAsync(x=>x.CompanyID == id);
        }

        private ShopDbContext ShopDbContext
        {
            get { return Context as ShopDbContext; }
        }
    }
}