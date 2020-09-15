using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test3_mail_web_api.Models;

namespace test3_mail_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mails1Controller : ControllerBase
    {
        private readonly MailsContext _context;

        public Mails1Controller(MailsContext context)
        {
            _context = context;
        }

        // GET: api/Mails1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mail>>> GetMails()
        {
            return await _context.Mails.ToListAsync();
        }

        // GET: api/Mails1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mail>> GetMail(int id)
        {
            var mail = await _context.Mails.FindAsync(id);

            if (mail == null)
            {
                return NotFound();
            }

            return mail;
        }

        // PUT: api/Mails1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMail(int id, Mail mail)
        {
            if (id != mail.MailID)
            {
                return BadRequest();
            }

            _context.Entry(mail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mails1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mail>> PostMail(Mail mail)
        {
            _context.Mails.Add(mail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMail", new { id = mail.MailID }, mail);
        }

        // DELETE: api/Mails1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mail>> DeleteMail(int id)
        {
            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }

            _context.Mails.Remove(mail);
            await _context.SaveChangesAsync();

            return mail;
        }

        private bool MailExists(int id)
        {
            return _context.Mails.Any(e => e.MailID == id);
        }
    }
}
