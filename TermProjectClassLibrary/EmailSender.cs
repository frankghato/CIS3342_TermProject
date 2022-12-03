using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace TermProjectLibrary
{
    public class EmailSender
    {
        public EmailSender()
        {

        }

        public Boolean SendConfirmationEmail(string emailAddress, string code)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(emailAddress);
                message.From = new MailAddress("mail@socialmedia.com");
                message.Subject = "Confirm your email";
                message.Body = "Here is your confirmation code: " + code;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;
                SmtpClient mailClient = new SmtpClient("smtp.temple.edu");
                mailClient.Send(message);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
