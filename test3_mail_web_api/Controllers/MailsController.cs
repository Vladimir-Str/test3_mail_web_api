using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test3_mail_web_api.Models;
using test3_mail_web_api.Services;


namespace test3_mail_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : Controller
    {
        MailsContext db;

        public MailsController(MailsContext context)
        {
            db = context;
            if (!db.Mails.Any())
            {
                //db.Mails.Add(new Mail("Achtung", "Some text about achtung", "111@111.ru, 222@222.ru")); 
                db.Mails.Add(new Mail { Subject = "Тест", Body = "Тестовая запись", Recipients = "111@111.ru, 222@222.ru" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mail>>> Get()
        {
            return await db.Mails.ToListAsync();
        }


        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Mail>> Post(Mail mail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var maildto = new Mail
            {
                Subject = mail.Subject,
                Body = mail.Body,
                CreateDate = DateTime.UtcNow,
                Result = "Failed",
                FailedMessage = "Неизвестная ошибка при отправке email",
                Recipients = mail.Recipients
            };

            List<string> Recipients = maildto.Recipients.Split(',').ToList();
            EmailService emailService = new EmailService();
            foreach (string recipient in Recipients)
            { 
                await emailService.SendEmailAsync(recipient, maildto.Subject, maildto.Body); 
            }

            maildto.FailedMessage = "";
            maildto.Result = "Ok";
            db.Mails.Add(maildto);
            await db.SaveChangesAsync();
            return Ok(maildto);
        }


    }
}
