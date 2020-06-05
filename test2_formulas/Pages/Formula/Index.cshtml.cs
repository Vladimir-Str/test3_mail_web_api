using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using test2_formulas.Data.Models;
using test2_formulas.Data;

namespace test2_formulas.Pages.Formula
{
    public class IndexModel : PageModel
    {
        private readonly test2_formulas.Data.Models.ApplicationDbContext _context;

        public IndexModel(test2_formulas.Data.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }
        public PaginatedList<Expr> Exprs { get; set; }
  //      public IList<Expr> Expr { get;set; }

        public async Task OnGetAsync(string searchString, int? pageIndex, string currentFilter)
        {
            CurrentFilter = searchString;

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Expr> ExprIQ = from e in _context.Expressions.Include("User") select e;
                                             
            if (!String.IsNullOrEmpty(searchString))
            {
                ExprIQ = ExprIQ.Where(e => e.User.NormalizedUserName.Contains(searchString.ToUpper()));
            }
            int pageSize = 6;

            Exprs = await PaginatedList<Expr>.CreateAsync(ExprIQ.AsNoTracking(),pageIndex ?? 1, pageSize);
        }
    }
}
