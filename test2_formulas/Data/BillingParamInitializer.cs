using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace test2_formulas.Data.Models
{
    public class BillingParamInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context)
        {
            if (await context.BillingParams.AnyAsync())
            {
                return;
            }

            var billingparam = new BillingParam { 
                MinuteCost = 10.5M,  
                TimeCoef = 0.5D, 
                StartTime = DateTime.Parse("00:00:00"), 
                EndTime = DateTime.Parse("06:00:00") };
            await context.BillingParams.AddAsync(billingparam);
            await context.SaveChangesAsync();
        }
        
        
    }
}