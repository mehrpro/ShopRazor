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

namespace Netyar.Pages.Companies
{
    public class DetailsModel : PageModel
    {
        private readonly ICompanyServices companyServices;

        public DetailsModel(ICompanyServices companyServices)
        {
            this.companyServices = companyServices;
        }

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
    }
}
