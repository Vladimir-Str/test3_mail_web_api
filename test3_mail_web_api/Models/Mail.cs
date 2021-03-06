﻿using System;
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
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Поле Subject должно быть от 3 до 50 символов")]
        public string Subject { get; set; }

        /// <value> Текст направляемого письма </value>
        [Required(ErrorMessage = "Введите текст письма")]
        public string Body{ get; set; }

        /// <value> Дата создания записи UTC </value>
        [DisplayFormat(DataFormatString = "{0:f}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        /// <value> Результат отправки Ok или Failed </value>
        public string Result { get; set; }

        /// <value> Текст ошибки в случае если письмо не было отправлено </value>
        public string FailedMessage { get; set; }

        /// <value> Recipients должно содержать строку с адресами разделенными ',' </value>
        /// <example>1111@yandex.ru,2222@yandex.ru</example>
        [Required(ErrorMessage = "Укажите адресатов")]
        [RegularExpression(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[,]{0,1}\s*)+$", ErrorMessage = "Строка содержит некорректные адреса")]
        [StringLength(2500, ErrorMessage = "Recipients должно быть не более 2500 символов и не должно содержать более 100 адресатов(для Gmail)")]
        public string Recipients { get; set; }

    }
}
