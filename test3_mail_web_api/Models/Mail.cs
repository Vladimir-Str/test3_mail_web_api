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

        /// <value> Поле тема, направляемого письма </value>
        [Required(ErrorMessage = "Задайте тему письма")]
        public string Subject { get; set; }

        /// <value> Текст направляемого письма </value>
        [Required(ErrorMessage = "Введите текст письма")]
        public string Body{ get; set; }

        /// <value> Дата создания записи UTC </value>
        public DateTime CreateDate { get; set; }

        /// <value> Результат отправки Ok или Failed </value>
        public string Result { get; set; }

        /// <value> Текст ошибки в случае если письмо не было отправлено </value>
        public string FailedMessage { get; set; }

        /// <value> Recipients должно содержать строку с адресами разделенными ',' </value>
        /// <example>1111@yandex.ru,2222@yandex.ru</example>
        [Required(ErrorMessage = "Укажите адресатов")]
        [RegularExpression(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[,]{0,1}\s*)+$", ErrorMessage = "Строка содержит некорректные адреса")]
        public string Recipients { get; set; }

    }
}
