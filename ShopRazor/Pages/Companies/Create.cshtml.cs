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

namespace ShopRazor.Pages.Companies
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
        public Company _company { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await companyServices.CreateCompany(_company);

            return RedirectToPage("./Index");
        }
    }
}
