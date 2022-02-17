using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Services;
using Entities;

namespace Netyar.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly IDepartmentServices departmentServices;

        public IndexModel(IDepartmentServices departmentServices)
        {
            this.departmentServices = departmentServices;
        }

        public IList<Department> Department { get;set; }

        public async Task OnGetAsync()
        {
            var result = await departmentServices.GetAllWithCompany();
            Department =  result.ToList();
        }
    }
}
