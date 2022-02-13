using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Services;
using Entities;
using Core;

namespace ShopRazor.Pages.Companies
{
    public class DeleteModel : PageModel
    {
        private readonly ICompanyServices companyServices;

        public DeleteModel(ICompanyServices companyServices)
        {
            this.companyServices = companyServices;
        }

        [BindProperty]
        public Company _company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _company = await companyServices.GetCompanyById((int)id);

            if (_company == null)
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

            _company = await companyServices.GetCompanyById((int)id);

            if (_company != null)
            {
               await  companyServices.DeleteCompany(_company);
            }

            return RedirectToPage("./Index");
        }
    }
}
