using System.Net.Mail;

namespace SanpetePantry.Services;

public class SmtpClientMailService : IMailService
{
    public Task SendMessageAsync(string from, string to, string subject, string body)
    {
        using var mail = new MailMessage()
        {
            From = new MailAddress("contact@sanpetepantry.org"),            
            Subject = "Contact Page: Email from website",
            Body = body,
            IsBodyHtml = true
        };
        mail.To.Add("contact@sanpetepantry.org");

        using var smtp = new SmtpClient("sanpetepantry-org.mail.protection.outlook.com", 25);
        smtp.EnableSsl = true;
        smtp.Send(mail); 

        return Task.CompletedTask;
    }
}
