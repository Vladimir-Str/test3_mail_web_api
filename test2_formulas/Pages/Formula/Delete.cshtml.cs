using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using test2_formulas.Data.Models;

namespace test2_formulas.Pages.Formula
{
    public class DeleteModel : PageModel
    {
        private readonly test2_formulas.Data.Models.ApplicationDbContext _context;

        public DeleteModel(test2_formulas.Data.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Expr Expr { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expr = await _context.Expressions.FirstOrDefaultAsync(m => m.ExprID == id);

            if (Expr == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expr = await _context.Expressions.FindAsync(id);

            if (Expr != null)
            {
                _context.Expressions.Remove(Expr);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
