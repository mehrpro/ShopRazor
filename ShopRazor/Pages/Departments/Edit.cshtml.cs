using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Services;
using Entities;

namespace ShopRazor.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly IDepartmentServices departmentServices;
        private readonly ICompanyServices companyServices;

        public EditModel(IDepartmentServices departmentServices , ICompanyServices companyServices)
        {
            this.departmentServices = departmentServices;
            this.companyServices = companyServices;
        }

        [BindProperty]
        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await departmentServices.GetWithCompanyByDepartmentId((int)id);

            if (Department == null)
            {
                return NotFound();
            }
            var companyList = await companyServices.GetAllCompany();
           ViewData["CompanyID_FK"] = new SelectList(companyList, "CompanyID", "CompanyTitle");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

          await  departmentServices.UpdateDepartment(Department);

            return RedirectToPage("./Index");
        }

        private async Task<bool> DepartmentExists(int id)
        {
            return  Convert.ToBoolean(await departmentServices.GetDepartmentById(id));
        }
    }
}
