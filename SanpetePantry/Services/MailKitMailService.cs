using MimeKit;

namespace SanpetePantry.Services;

public class MailKitMailService : IMailService
{
    public async Task SendMessageAsync(string from, string to, string subject, string body)
    {
        using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
        await smtpClient.ConnectAsync("sanpetepantry-org.mail.protection.outlook.com", 25, MailKit.Security.SecureSocketOptions.Auto);
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(from, from));
        message.To.Add(new MailboxAddress(to, to));
        message.Subject = subject;
        message.Body = new TextPart("html")
        {
            Text = body
        };
        await smtpClient.SendAsync(message);
        await smtpClient.DisconnectAsync(true);
    }
}
