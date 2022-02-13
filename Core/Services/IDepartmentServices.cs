using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Core.Services
{
    public interface IDepartmentServices
    {
        Task<IEnumerable<Department>> GetAllWithCompany();
        Task<Department> GetDepartmentById(int id);
        Task<IEnumerable<Department>> GetAllDepartmentByCompanyId(int companyId);
        Task<Department> GetDepartmentByCompanyId(int companyId);
        Task<Department> CreateDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task DeleteDepartment(Department department);
    }
}
