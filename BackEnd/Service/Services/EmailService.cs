using MailKit.Net.Smtp;
using MimeKit;
using Service.Models;

namespace Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailService(EmailConfiguration emailConfig) => _emailConfig = emailConfig;

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Jasmine Recruitment", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            // You could use HTML formatting if you want a richer email content
            var builder = new BodyBuilder
            {
                HtmlBody = $@"<p>Hello,</p>
                      <p>Please click on the following link to verify your account:</p>
                      <p><a href='{message.Content}'>Click here</a></p>
                      <p>If you did not request an account, no further action is required.</p>
                      <p>Regards,<br>~~~Jasmine Recruitment Team~~~</p>"
            };

            emailMessage.Body = builder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                client.Send(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception or both
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}