using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NotificationMaker
{
    public class EmailSender
    {
        public static void SendEmail(string SendTo, string Subject, string MessageBody)
        { 
            string fromEmail = string.Format("{0}@gmail.com", "tpa2221");
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(fromEmail);
            mail.To.Add(SendTo);
            mail.Subject = Subject;
            mail.Body = MessageBody;
                 

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(fromEmail, "tpa22tpa22");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail); 
            
        }
    }
}
