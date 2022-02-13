using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Services;
using Entities;

namespace ShopRazor.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly IDepartmentServices departmentServices;

        public DetailsModel(IDepartmentServices departmentServices )
        {
            this.departmentServices = departmentServices;
        }

        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await departmentServices.GetDepartmentById((int)id);

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
