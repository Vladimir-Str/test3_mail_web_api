using Microsoft.EntityFrameworkCore;

namespace test3_mail_web_api.Models
{
    /// <summary> Контекст базы данных </summary>
    public class MailsContext : DbContext
    {
        /// <value> Таблица mails содержит данные post запросов и результаты отправки email </value>
        public DbSet<Mail> Mails { get; set; }
        public MailsContext(DbContextOptions<MailsContext> options)
            : base(options)
        {
           // Database.EnsureCreated();
        }
    }
}
