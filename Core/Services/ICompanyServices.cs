using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICompanyServices
    {
        Task<IEnumerable<Company>> GetAllCompany();
        Task<Company> GetCompanyById(int id);
        Task<Company> CreateCompany(Company company);
        Task UpdateCompany(Company company);
        Task DeleteCompany(Company company);

    }
}
