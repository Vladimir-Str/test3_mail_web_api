using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test3_mail_web_api.Models
{
    public class Mail
    {
        public int MailID { get; set; }
        public string Subject { get; set; }
        public string Body{ get; set; }
        public DateTime CreateDate { get; set; }
        public bool SuccesResult { get; set; }
        public string FailedMessage { get; set; }
        public string Recipients { get; set; }

        //    public ICollection<Recipient> Recipients { get; set; }
    }
}
