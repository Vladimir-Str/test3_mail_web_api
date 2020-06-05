using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test2_formulas.Data.Models;

namespace test2_formulas.Pages.Billing
{
    public class EditModel : PageModel
    {
        private readonly test2_formulas.Data.Models.ApplicationDbContext _context;

        public EditModel(test2_formulas.Data.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BillingParam BillingParam { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            BillingParam = await _context.BillingParams.FirstOrDefaultAsync(m => m.BillingParamID == 1);

            if (BillingParam == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BillingParam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillingParamExists(BillingParam.BillingParamID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Page();
        }

        private bool BillingParamExists(int id)
        {
            return _context.BillingParams.Any(e => e.BillingParamID == id);
        }
    }
}
