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
    public class MailController : Controller
    {
        MailContext db;

        public MailController(MailContext context)
        {
            db = context;
            if (!db.Mails.Any())
            {
                db.Mails.Add(new Mail { Subject = "Achtung", Body = "Some text about achtung", CreateDate = DateTime.Now, Recipients= "111@111.ru, 222@222.ru", SuccesResult = true }); 
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
            if (mail == null)
            {
                return BadRequest();
            }
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync("jkr3@yandex.ru", "Тема письма", "Тест письма: тест!");

            db.Mails.Add(mail);
            await db.SaveChangesAsync();
            return Ok(mail);
        }


    }
}
