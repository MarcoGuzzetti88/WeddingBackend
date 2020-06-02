using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Wedding.Backend.Domain;

namespace Wedding.Backend.BLL
{
    public class GmailSender : IEmailSender
    {
        private static string[] Scopes = { GmailService.Scope.GmailSend };
        private static string ApplicationName = "WeddingSender";

        private readonly UserCredential credential;

        public GmailSender()
        {
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
        }

        public void Send(Email email)
        {
            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            SendEmail(service, "me", email);
        }

        private string Encode(string text)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);

            return System.Convert.ToBase64String(bytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }

        public void SendEmail(GmailService service, string userId, Email email)
        {
            var mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress(email.From);
            mailMessage.To.Add(email.To);
            mailMessage.ReplyToList.Add(email.From);
            mailMessage.Subject = email.Subject;
            mailMessage.Body = email.Message;
            mailMessage.IsBodyHtml = true;

            foreach (var ccn in email.Ccn)
                mailMessage.Bcc.Add(ccn);

            //foreach (System.Net.Mail.Attachment attachment in email.Attachments)
            //{
            //    mailMessage.Attachments.Add(attachment);
            //}

            var mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(mailMessage);

            var gmailMessage = new Google.Apis.Gmail.v1.Data.Message
            {
                Raw = Encode(mimeMessage.ToString())
            };

            Google.Apis.Gmail.v1.UsersResource.MessagesResource.SendRequest request = service.Users.Messages.Send(gmailMessage, userId);

            request.Execute();
        }
    }
}