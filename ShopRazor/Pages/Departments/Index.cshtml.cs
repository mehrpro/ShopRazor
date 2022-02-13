using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities;

namespace ShopRazor.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly Data.ShopDbContext _context;

        public IndexModel(Data.ShopDbContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; }

        public async Task OnGetAsync()
        {
            Department = await _context.Departments
                .Include(d => d.Company).ToListAsync();
        }
    }
}
