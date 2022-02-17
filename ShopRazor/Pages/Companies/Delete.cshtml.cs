using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Services;
using Entities;
using Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Netyar.DTO.CompaniesDTO;

namespace Netyar.Pages.Companies
{
    public class DeleteModel : PageModel
    {
        private readonly ICompanyServices companyServices;
        private readonly IMapper _mapper;

        public DeleteModel(ICompanyServices companyServices, IMapper mapper)
        {
            this.companyServices = companyServices;
            _mapper = mapper;
        }

        [BindProperty]
        public CompanyDeleteDTO _company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultFind = await companyServices.GetCompanyByIdWithDepartments((int)id);



            if (resultFind == null)
            {
                return NotFound();
            }

            _company = _mapper.Map<CompanyDeleteDTO>(resultFind);
            ViewData["DepartmentsList"] = new SelectList(_company.Departments, "DepartmentID", "DepartmentTitle");


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultFind = await companyServices.GetCompanyById((int)id);

            if (resultFind != null)
            {
                await companyServices.DeleteCompany(resultFind);
            }

            return RedirectToPage("./Index");
        }
    }
}
