using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using test2_formulas.Data.Models;

namespace test2_formulas.Pages.Payments
{
    [Authorize(Roles = "admin")]
    public class CreateModel : PageModel
    {
        private readonly test2_formulas.Data.Models.ApplicationDbContext _context;

        public CreateModel(test2_formulas.Data.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            return Page();
        }
        
        [BindProperty]
        public Payment Payment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyPayment = new Payment();

            if (await TryUpdateModelAsync<Payment>(
                emptyPayment,
                "payment",   // Prefix for form value.
                p => p.UserId, p => p.PaymentSum, p => p.PaymentDate))
            {
                _context.Payments.Add(emptyPayment);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
