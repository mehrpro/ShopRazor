using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities;
using Core;
using Core.Services;

namespace ShopRazor.Pages.Companies
{
    public class EditModel : PageModel
    {
        private readonly ICompanyServices companyServices;

        public EditModel(ICompanyServices companyServices)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Company).State = EntityState.Modified;
          await   companyServices.UpdateCompany(_company);

            //try
            //{
            //    await unitOfWork.CommitAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CompanyExists(_company.CompanyID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        private bool CompanyExists(int id)
        {
            return Convert.ToBoolean(companyServices.GetCompanyById(id));
        }
    }
}
