using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Services;
using Entities;

namespace Netyar.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly IDepartmentServices departmentServices;
        private readonly ICompanyServices companyServices;

        public CreateModel(IDepartmentServices departmentServices,ICompanyServices companyServices)
        {
            this.departmentServices = departmentServices;
            this.companyServices = companyServices;
        }

        public async Task<IActionResult> OnGet()
        {
            var companyList = await companyServices.GetAllCompany();
            ViewData["CompanyID_FK"] = new SelectList(companyList, "CompanyID", "CompanyTitle");
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            departmentServices.CreateDepartment(Department);

            return RedirectToPage("./Index");
        }
    }
}
