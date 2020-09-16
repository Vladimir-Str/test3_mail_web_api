using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test3_mail_web_api.Services
{
    public interface ISender
    {
        Task SendAsync(List<string> recipients, string subject, string message);
    }
}
