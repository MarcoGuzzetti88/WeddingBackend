using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Wedding.Backend.Domain;

namespace Wedding.Backend.BLL
{
    public class GmailSmtpSender : IEmailSender
    {
        public GmailSmtpSender()
        {
        }

        public void Send(Email email)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(email.To, email.To));
                message.From = new MailAddress(email.From, "Francy e Marco");

                foreach (var ccn in email.Ccn)
                    message.Bcc.Add(new MailAddress(ccn, ccn));

                message.Subject = email.Subject;
                message.Body = email.Message;
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("marco.guzzetti88@gmail.com", "mlrwzazkctahnonb");
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
        }
    }
}