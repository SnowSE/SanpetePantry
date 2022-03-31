using MimeKit;

namespace SanpetePantry.Services;

public class MailKitMailService : IMailService
{
    private const string SmptHost = "sanpetepantry-org.mail.protection.outlook.com";
    private readonly JsConsole jsConsole;

    public MailKitMailService(JsConsole jsConsole)
    {
        this.jsConsole = jsConsole;
    }

    public async Task SendMessageAsync(string from, string to, string subject, string body)
    {
        using var smtpClient = new MailKit.Net.Smtp.SmtpClient();

        await jsConsole.LogAsync("Connecting to " + SmptHost);
        await smtpClient.ConnectAsync(SmptHost, 25, MailKit.Security.SecureSocketOptions.Auto);

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(from, from));
        message.To.Add(new MailboxAddress(to, to));
        message.Subject = subject;
        message.Body = new TextPart("html")
        {
            Text = body
        };

        await jsConsole.LogAsync("Attempting to send message");
        await smtpClient.SendAsync(message);

        await jsConsole.LogAsync("Disconnecting from server");
        await smtpClient.DisconnectAsync(true);
    }
}
