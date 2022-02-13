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
            throw new System.NotImplementedException();
        }

        public async Task<Company> GetWithDepartmentId(int id)
        {
            throw new System.NotImplementedException();
        }

        private ShopDbContext ShopDbContext
        {
            get { return Context as ShopDbContext; }
        }
    }
}