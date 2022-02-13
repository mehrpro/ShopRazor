using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRep Companies { get; }
        IDepartmentRep Departments { get; }
        Task<int> CommitAsync();
    }
}
