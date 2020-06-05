using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using test2_formulas.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace test2_formulas.Pages.Formula
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly test2_formulas.Data.Models.ApplicationDbContext _context;
        private UserManager<User> _userManager;


        public CreateModel(test2_formulas.Data.Models.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Expr Expr { get; set; }



        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            var emptyExpr = new Expr();
            
        Stopwatch stopWatch = new Stopwatch();



            if (await TryUpdateModelAsync<Expr>(
                 emptyExpr,
                 "Expr",
                 s => s.Expression))
            {
                stopWatch.Start();
                try
                {

                    var result = new DataTable().Compute(emptyExpr.Expression, null);

                    emptyExpr.Result = result.ToString();
                }
                catch (Exception ex)
                {
                    emptyExpr.Result = ex.Message;
                }

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = ts.TotalMilliseconds.ToString();
                emptyExpr.TimeSpan = elapsedTime;

                var user = await _userManager.GetUserAsync(User);
                emptyExpr.User = user;

                BillingParam billingparam = await _context.BillingParams.FirstOrDefaultAsync(b => b.BillingParamID == 1);
                decimal minutecost = billingparam.MinuteCost;
                DateTime starttime = billingparam.StartTime;
                DateTime endtime = billingparam.EndTime;
                double timecoef = billingparam.TimeCoef;

                if (DateTime.UtcNow.TimeOfDay > starttime.TimeOfDay  && DateTime.UtcNow.TimeOfDay < endtime.TimeOfDay )
                { 
                    emptyExpr.Cost = (double)minutecost * timecoef * ts.TotalMilliseconds / 1000 / 60;
                    
                }
                else
                {
                    emptyExpr.Cost = (double)minutecost * ts.TotalMilliseconds / 1000 / 60;
                }
                _context.Expressions.Add(emptyExpr);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
