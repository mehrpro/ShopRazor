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
    public class DepartmentServices : IDepartmentServices

    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            await unitOfWork.Departments.AddAsync(department);
            await unitOfWork.CommitAsync(); 
            return department;
        }

        public async Task DeleteDepartment(Department department)
        {
           unitOfWork.Departments.Remove(department);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Department>> GetAllWithCompany()
        {
            return await unitOfWork.Departments.GetAllWithCompanyAsync();
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentByCompanyId(int companyId)
        {
            return await unitOfWork.Departments.GetAllWithCompanyBYCompanyIdAsync(companyId);   
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await unitOfWork.Departments.GetByIdAsync(id);
        }

        public async Task UpdateDepartment(Department department)
        {
           unitOfWork.Departments.UpdateDisconected(department);
            await unitOfWork.CommitAsync();
        }

        public async Task<Department> GetWithCompanyByDepartmentId(int departmentId)
        {
            return await unitOfWork.Departments.GetWithCompanyByDepartmentIdAsync(departmentId);
        }
    }
}
