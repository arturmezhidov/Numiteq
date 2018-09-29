using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Configuration;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return SendEmailAsync(new List<string> { email }, subject, message);
        }

        public Task SendEmailAsync(IEnumerable<string> emails, string subject, string message)
        {
            SmtpClient client = new SmtpClient(PlatformConfiguration.SmtpServerName);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(PlatformConfiguration.SmtpEmailAddress, PlatformConfiguration.SmtpEmailPassword);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(PlatformConfiguration.SmtpEmailAddress);
            mailMessage.Body = message;
            mailMessage.Subject = subject;

            foreach (string email in emails)
            {
                mailMessage.To.Add(email);
            }

            return client.SendMailAsync(mailMessage);
        }
    }
}