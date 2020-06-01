using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using test2_formulas.Data.Models;

namespace test2_formulas.Pages.Payments
{
    [Authorize(Roles = "admin")]
    public class IndexModel : PageModel
    {
        private readonly test2_formulas.Data.Models.ApplicationDbContext _context;

        public IndexModel(test2_formulas.Data.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Payment> Payment { get;set; }

        public async Task OnGetAsync()
        {
            Payment = await _context.Payments
                .Include(p => p.User).ToListAsync();
        }
    }
}
