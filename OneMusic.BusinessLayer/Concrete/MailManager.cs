
using MailKit.Net.Smtp;
using MimeKit;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.BusinessLayer.Concrete
{
    public class MailManager : IMailService
    {
        public void sendMail(string mail, string subject, string content)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAdressFrom = new MailboxAddress("Admin", "aspnetcoreprojeler@gmail.com");
            mimeMessage.From.Add(mailboxAdressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("üye", mail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = content;

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("aspnetcoreprojeler@gmail.com", "bbjy hwhd ikzd clzk");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
        }
    }
}
