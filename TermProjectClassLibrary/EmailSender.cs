using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace TermProjectLibrary
{
    public class EmailSender
    {
        SmtpClient mailClient = new SmtpClient("mail.socialmedia.com", 25);

        public void SendWelcomeEmail(string email)
        {
            mailClient.Credentials = new System.Net.NetworkCredential("info@socialmedia.com", "myIDPassword");
            mailClient.UseDefaultCredentials = true;
            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailClient.EnableSsl = true;
            MailMessage message = new MailMessage();

            message.From = new MailAddress("info@socialmedia.com", "Social Media");
            message.To.Add(new MailAddress(email));

            mailClient.Send(message);
        }

    }
}
