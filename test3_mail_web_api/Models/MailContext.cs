using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace test3_mail_web_api.Models
{
    public class MailContext : DbContext
    {
        public DbSet<Mail> Mails { get; set; }
 //       public DbSet<Recipient> Recipients { get; set; }
        public MailContext(DbContextOptions<MailContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
