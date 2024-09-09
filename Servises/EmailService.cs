using MailKit.Net.Smtp;
using MimeKit;

using HsptMS.Abstract;
using HsptMS.Data.DTO;
using HsptMS.Data.Models;
using MailKit.Security;
using MimeKit.Text;

public class EmailService:IEmailService
{
    private readonly EmailConfiguration _emailConfiguration;

    public EmailService(EmailConfiguration emailConfiguration)
    {
        _emailConfiguration = emailConfiguration;
    }



    public void SendEmail(SendEmailDto emailDto)
    {
        var email = new MimeMessage
        {
            Subject = emailDto.Subject,
            Body = new TextPart(TextFormat.Html) { Text = emailDto.Html },
            From = { MailboxAddress.Parse(_emailConfiguration.From) },
            To = { MailboxAddress.Parse(emailDto.To) }
        };

        using var smtp = new SmtpClient();
        smtp.Connect(_emailConfiguration.Host, _emailConfiguration.Port , SecureSocketOptions.StartTls);
        smtp.Authenticate(_emailConfiguration.From, _emailConfiguration.Password);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}
