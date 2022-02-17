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
    public class DeleteModel : PageModel
    {
        private readonly IDepartmentServices departmentServices;

        public DeleteModel(IDepartmentServices departmentServices)
        {
            this.departmentServices = departmentServices;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await departmentServices.GetDepartmentById((int)id);

            if (Department != null)
            {
                await departmentServices.DeleteDepartment(Department);
            }

            return RedirectToPage("./Index");
        }
    }
}
