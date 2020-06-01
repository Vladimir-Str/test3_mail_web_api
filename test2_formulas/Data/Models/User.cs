using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace test2_formulas.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<Expr> Expressions { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
