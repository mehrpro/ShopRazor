using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Services;
using Entities;

namespace Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly IUnitOfWork unitOfWork;

        public CompanyServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Company> CreateCompany(Company company)
        {
            await unitOfWork.Companies.AddAsync(company);
            await unitOfWork.CommitAsync();
            return company;
        }

        public async Task DeleteCompany(Company company)
        {
            unitOfWork.Companies.Remove(company);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Company>> GetAllCompany()
        {
            return await unitOfWork.Companies.GetAllAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await unitOfWork.Companies.GetByIdAsync(id);
        }

        public async Task UpdateCompany(Company company)
        {
            unitOfWork.Companies.UpdateDisconected(company);
            await unitOfWork.CommitAsync();

        }
    }
}
