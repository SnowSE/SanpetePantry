using MimeKit;

namespace SanpetePantry.Services;

public class MailKitMailService : IMailService
{
    private const string SmptHost = "sanpetepantry-org.mail.protection.outlook.com";

    public MailKitMailService()
    {
    }

    public async Task SendMessageAsync(string from, string to, string subject, string body, Action<string>? log = null)
    {
        using var smtpClient = new MailKit.Net.Smtp.SmtpClient();

        log?.Invoke("Connecting to " + SmptHost);
        await smtpClient.ConnectAsync(SmptHost, 25, MailKit.Security.SecureSocketOptions.Auto);

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(from, from));
        message.To.Add(new MailboxAddress(to, to));
        message.Subject = subject;
        message.Body = new TextPart("html")
        {
            Text = body
        };

        log?.Invoke("Attempting to send message");
        await smtpClient.SendAsync(message);

        log?.Invoke("Disconnecting from server");
        await smtpClient.DisconnectAsync(true);
    }
}
