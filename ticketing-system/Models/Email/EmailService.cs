using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace ticketing_system.Models.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task sendMailAsync(string emailTo, int generatedCode)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress
                (
                _emailSettings.SenderEmail,
                "Your ticketing system"
                );
            mailMessage.To.Add(emailTo);
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = "Confirm code";
            mailMessage.Body =
                @"<p>This email contains 6 character code which you need to enter into input field in applicaion.</p><br>" +
                "<p>You have 5 minutes before code expire.</p><br>" +
                "<p>The code is: </p>" +
                "<h2>" + generatedCode + "</h2>";

            var client = new SmtpClient(_emailSettings.SmtpServer)
            {
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential
                (
                    _emailSettings.SenderEmail,
                    _emailSettings.SenderPassword
                ),
                EnableSsl = true
            };

            using (client)
            {
                try
                {
                    await client.SendMailAsync(mailMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while sending email: " + ex.ToString());
                }
            }
        }
    }
}
