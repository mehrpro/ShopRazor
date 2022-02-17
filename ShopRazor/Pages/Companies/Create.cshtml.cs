using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Services;
using Entities;
using Core;
using Netyar.DTO.CompaniesDTO;

namespace Netyar.Pages.Companies
{
    public class CreateModel : PageModel
    {
        private readonly ICompanyServices companyServices;

        public CreateModel(ICompanyServices companyServices)
        {
            this.companyServices = companyServices;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CompanyCreateDTO _company { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newCompany = new Company
            {

                CompanyTitle = _company.CompanyTitle,
                Description = _company.Description,
                IsActive = true,
                IsDelete = false,
                CreateDatetime = DateTime.Now,
                ModifidDatetime = DateTime.Now,
                DeleteDatetime = DateTime.Now,

            };
            await companyServices.CreateCompany(newCompany);

            return RedirectToPage("./Index");
        }
    }
}
