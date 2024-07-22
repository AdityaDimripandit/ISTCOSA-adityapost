using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace ISTCOSA.Infrastructure.Utility
{
    public class EmailService : IEmailSender
    {
        private readonly EmailSetting _setting;
        public EmailService(IOptions<EmailSetting> setting)
        {
            _setting = setting.Value;
        }

        public async Task Execute(string email, string subject, string Message)
        {
            try
            {
                string toEmail = string.IsNullOrEmpty(email) ? _setting.ToEmail : email;
                MailMessage mailMessage = new MailMessage()
                {
                    From = new MailAddress(_setting.FromEmail, "ISTCOSA"),
                };
                mailMessage.To.Add(toEmail);
                mailMessage.CC.Add(_setting.CcEmail);
                mailMessage.Subject = subject;
                mailMessage.Body = Message;
                mailMessage.IsBodyHtml = false;
                mailMessage.Priority = MailPriority.High;
                using (SmtpClient smtp = new SmtpClient(_setting.PrimaryDomain, _setting.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_setting.UserNameEmail, _setting.UserNamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mailMessage);
                };
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
            }
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Execute(email, subject, htmlMessage).Wait();
            return Task.FromResult(0);

        }
    }
}
