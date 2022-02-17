using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities;
using Core;
using Core.Services;
using Netyar.DTO.CompaniesDTO;

namespace Netyar.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly ICompanyServices companyServices;

        public IndexModel(ICompanyServices companyServices)
        {

            this.companyServices = companyServices;
        }

        public IList<CompanyListDTO> CompanyList { get; set; }

        public async Task OnGetAsync()
        {
            var result = await companyServices.GetAllCompanyWithDepartment();

            CompanyList = new List<CompanyListDTO>();
            foreach (var company in result.ToList())
            {
                var dto = new CompanyListDTO();
                dto.CompanyID = company.CompanyID;
                dto.CompanyTitle = company.CompanyTitle;
                dto.CountDepartment = company.Departments.Count;
                CompanyList.Add(dto);
            }

        }
    }
}
