using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities;
using Core;
using Core.Services;
using Netyar.DTO.CompaniesDTO;

namespace Netyar.Pages.Companies
{
    public class EditModel : PageModel
    {
        private readonly ICompanyServices companyServices;
        private readonly IMapper _mapper;

        public EditModel(ICompanyServices companyServices, IMapper mapper)
        {
            this.companyServices = companyServices;
            _mapper = mapper;
        }

        [BindProperty]
        public CompanyEditDTO _company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await companyServices.GetCompanyById((int)id);

            if (result == null)
            {
                return NotFound();
            }

            _company = _mapper.Map<CompanyEditDTO>(result);

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _company.ModifidDatetime = DateTime.Now;
            var companyUpdate = _mapper.Map<Company>(_company);

            await companyServices.UpdateCompany(companyUpdate);


            return RedirectToPage("./Index");
        }

        private bool CompanyExists(int id)
        {
            return Convert.ToBoolean(companyServices.GetCompanyById(id));
        }
    }
}
