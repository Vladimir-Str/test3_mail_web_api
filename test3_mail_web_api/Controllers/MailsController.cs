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

    /// <summary>
    /// MailsController обрабатывает два типа HTTP запросов GET,POST
    /// </summary>
    public class MailsController : Controller
    {     
       
        /// <summary>
        /// Конструктор контроллера получает контекст базы данных и заполняет ее первоначальными данными если база не содержит записей
        /// </summary>
        public MailsController(MailsContext context,ISender sender)
        {
            db = context;
            Sender = sender;
        }
        MailsContext db;
        ISender Sender;
        /// <summary>
        /// Метод get возвращает содержащиеся в бд записи
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mail>>> Get()
        {
            return await db.Mails.ToListAsync();
        }

        /// <summary>
        /// Метод post получает параметр типа mail, 
        /// создает maildto во избежании чрезмерной передачи данных в запросе,
        /// вызывает emailService.SendEmailAsync для каждого адресата
        /// добавляет новую запись в бд
        /// </summary>
        /// <param name="mail"> В параметре должны быть переданы 3 обязательных свойства Subject, Body, Recipients</param>
 
        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Mail>> Post(Mail mail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            mail.CreateDate = DateTime.UtcNow.ToUniversalTime();
            mail.Result = "Ok";
            mail.FailedMessage = "";
            mail.Recipients = mail.Recipients.Replace(" ", "");

            /// <value> Recipients должно содержать строку с адресами разделенными ',' </value>
            /// <example>1111@yandex.ru,2222@yandex.ru</example>
            List<string> Recipients = mail.Recipients.Split(',').ToList();

                try
                {
                    await Sender.SendAsync(Recipients, mail.Subject, mail.Body);
                }
                catch (Exception ex)
                {
                    mail.FailedMessage = ex.Message;
                    mail.Result = "Failed";
                }

            db.Mails.Add(mail);
            await db.SaveChangesAsync();
            return Ok(mail);
        }


    }
}
