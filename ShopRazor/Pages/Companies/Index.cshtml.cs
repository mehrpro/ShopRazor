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

namespace ShopRazor.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly ICompanyServices companyServices;

        public IndexModel(ICompanyServices companyServices)
        {
           
            this.companyServices = companyServices;
        }

        public IList<Company> _company { get;set; }

        public async Task OnGetAsync()
        {
            var result = await companyServices.GetAllCompany();
            _company = result.ToList();
        }
    }
}
