using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test3_mail_web_api.Models
{
    public class Recipient
    {
        public int RecipientID { get; set; }
        public string Email { get; set; }
        public Mail Mail { get; set; }
    }
}
