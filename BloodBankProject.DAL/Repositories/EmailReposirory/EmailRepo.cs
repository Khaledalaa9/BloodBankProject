using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.EmailReposirory
{
    public class EmailRepo : IEmailRepo
    {

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Khaled", "k59378968@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = message };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("k59378968@gmail.com", "K555@123");

                await client.SendAsync(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}
