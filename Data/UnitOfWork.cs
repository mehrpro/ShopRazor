using System.Threading.Tasks;
using Core;
using Core.Repositories;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext _context;
        private CompanyRep _companyRep;
        private DepartmentRep _departmentRep;

        public UnitOfWork(ShopDbContext context)
        {
            this._context = context;
        }

        public ICompanyRep Companies => _companyRep ??= new CompanyRep(_context);

        public IDepartmentRep Departments => _departmentRep ??= new DepartmentRep(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
