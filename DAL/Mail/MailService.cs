using System;
using System.Net;
using System.Net.Mail;

namespace Services.Mail
{
    public class MailService
    {
        private readonly SmtpClient smtpClient;
        public MailService()
        {
            this.smtpClient = new SmtpClient("smtp.gmail.com", 25);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("minks.anon@gmail.com", "PutinDag05");
        }

        public bool SendMessage(string receiverEmail, string subject, string body)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("minks.anon@gmail.com");
            message.To.Add(receiverEmail);
            message.Body = body;
            message.Subject = subject;

            bool isSuccess = false;
            try
            {
                this.smtpClient.Send(message);
                isSuccess = true;
            }
            catch(Exception e)
            {
                isSuccess = false;
            }

            return isSuccess;
        }
    }
}
