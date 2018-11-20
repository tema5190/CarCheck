using CarNumber.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;

namespace Services.Mail
{
    public class MailService
    {
        private readonly SmtpClient smtpClient;
        private readonly AppConfiguration configuration;

        public MailService(IOptions<AppConfiguration> configuration)
        {
            this.smtpClient = new SmtpClient("smtp.gmail.com", 25);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("minks.anon@gmail.com", "PutinDag05");
            smtpClient.EnableSsl = true;

            this.configuration = configuration.Value;
        }

        public bool SendEmailConfirmationEmail(string receiverEmail, string url)
        {
            return SendMessage(receiverEmail, "Please confirm your email", $"{this.configuration.BaseApiUrl}registration/confirm-email/{url}");
        }

        public bool SendMessage(string receiverEmail, string subject, string body)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress("minks.anon@gmail.com"),
                Body = body,
                Subject = subject,
            };
            message.To.Add(receiverEmail);

            bool isSuccess = false;
            try
            {
                smtpClient.Send(message);
                isSuccess = true;
            }
            catch(Exception e) // TODO: ADD Logger
            {
                isSuccess = false;
            }

            return isSuccess;
        }
    }
}
