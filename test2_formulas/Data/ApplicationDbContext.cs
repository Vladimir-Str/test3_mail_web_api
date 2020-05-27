﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test2_formulas.Data.Models;

namespace test2_formulas.Data.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          Database.EnsureCreated();
        }
        public DbSet<Expr> Expressions { get; set; }
    }
}
