using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace test3_mail_web_api.Services
{
    /// <summary>
    /// EmailService получает конфигурацию для подключения к smtp серверу
    /// Выполняет подключение и отправку писем, с переданными параметрами
    /// </summary>
    public class EmailSender : ISender
    {
        /// <summary>
        /// Конструктор EmailService считывает параметры подключения из файла "emailservice.json в MailConfig
        /// </summary>
        public EmailSender()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("emailservice.json");
            MailConfig = builder.Build();
        }
        public IConfiguration MailConfig { get; set; }

        /// <summary>
        /// метод SendEmailAsync принимает параметры: адресат, тема и сообщение
        /// из MailConfig получает конфигурацию для подключения к серверу
        /// выполняет подключение и отправку сообщения
        /// </summary>
        /// <param name="email"> Должно содержать корректный адрес электронной почты RFC-5321 </param>
        public async Task SendAsync(List<string> recipients, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(MailConfig["fromname"], MailConfig["from"]));
            foreach (string recipient in recipients)
            {
                //добавить проверку валидности
                emailMessage.To.Add(new MailboxAddress("", recipient));
            }
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = message };
            
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(MailConfig["smtp"], int.Parse(MailConfig["port"]),bool.Parse(MailConfig["use_ssl"]));
                await client.AuthenticateAsync(MailConfig["login"], MailConfig["password"]);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
