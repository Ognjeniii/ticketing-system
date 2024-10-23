using System.Net;
using System.Net.Mail;

namespace ticketing_system.Classes
{
    public class EmailSender
    {
        public async Task sendMailAsync(string emailTo, int generatedCode)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress
                (
                "mikamikictest12345@gmail.com",
                "Your ticketing system"
                );
            mailMessage.To.Add(emailTo);
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = "Confirm code";
            mailMessage.Body = 
                @"<p>This email contains 6 character code which you need to enter into input field in applicaion.<\p><br>" +
                "<p>You got 5 minutes before code expire.</p><br>" +
                "<p>The code is: </p>" +
                "<h2>" + generatedCode + "</h2>";

            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential
                (
                "mikamikictest12345@gmail.com",
                "mikamika1"
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
