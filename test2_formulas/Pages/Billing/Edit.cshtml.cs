using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test2_formulas.Data.Models;

namespace test2_formulas.Pages.Billing
{
    [Authorize(Roles = "admin")]
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


        public async Task<IActionResult> OnPostAsync()
        {
            var paramToUpdate = await _context.BillingParams.FindAsync(1);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (paramToUpdate == null)
            {
                return NotFound();
            }



            if (await TryUpdateModelAsync<BillingParam>(
                paramToUpdate,
                "BillingParam",
                b => b.MinuteCost,  b => b.TimeCoef, b => b.StartTime, b => b.EndTime))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }

            return Page();
        }


    }
}
