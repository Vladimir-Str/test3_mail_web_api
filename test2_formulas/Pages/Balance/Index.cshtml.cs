using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using test2_formulas.Data.Models;
using test2_formulas.Data;

namespace test2_formulas.Pages.Balance
{
    public class IndexModel : PageModel
    {
        private readonly test2_formulas.Data.Models.ApplicationDbContext _context;

        public IndexModel(test2_formulas.Data.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }
        public PaginatedList<User> Users { get; set; }

        public double balance;


        public async Task OnGetAsync(string searchString, int? pageIndex, string currentFilter)
        {
            

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<User> UserIQ = from u in _context.Users.Include("Expressions").Include("Payments") select u;
                                             
            if (!String.IsNullOrEmpty(searchString))
            {
                UserIQ = UserIQ.Where(e => e.NormalizedUserName.Contains(searchString.ToUpper()));
            }
            
            int pageSize = 6;
            Users = await PaginatedList<User>.CreateAsync(UserIQ.AsNoTracking(),pageIndex ?? 1, pageSize);
            

        }
    }
}
