using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test3_mail_web_api.Models
{
    public class Mail
    {
        public int MailID { get; set; }

        [Required(ErrorMessage = "Задайте тему письма")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Введите текст письма")]
        public string Body{ get; set; }
        public DateTime CreateDate { get; set; }
        public string Result { get; set; }
        public string FailedMessage { get; set; }

        [Required(ErrorMessage = "Укажите адресатов")]
        public string Recipients { get; set; }


        //    public ICollection<Recipient> Recipients { get; set; }
    }
}
