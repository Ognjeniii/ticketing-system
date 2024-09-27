using System.Net;
using System.Net.Mail;

namespace ticketing_system.Classes
{
    public class EmailSender
    {
        public int sendMail(string emailTo, int generatedCode)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress("email@maileroo.com");
            mailMessage.To.Add(emailTo);
            mailMessage.Subject = "Tcketing system";
            mailMessage.Body = @"<p>This email contains 6 character code which you need to enter into input field in applicaion.<\p><br>" +
                "<p>You got 5 minutes before code expire.</p><br>" +
                "<p>The code is: </p>" +
                "<h2>" + generatedCode + "</h2>";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.maileroo.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("SenderEmail", "SenderPassword");
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email Sent Successfully.");
                return generatedCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return -1;
            }
        }
    }
}
