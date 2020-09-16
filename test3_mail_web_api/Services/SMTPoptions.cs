using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test3_mail_web_api.Services
{
    public class SMTPoptions
    {
        public const string SMTP = "SMTP";
        public string Smtp { get; set; }
        public int Port { get; set; }
        public bool Use_ssl { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
        public string Fromname { get; set; }

    }
}
