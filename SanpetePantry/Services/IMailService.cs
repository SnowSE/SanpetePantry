namespace SanpetePantry.Services;

public interface IMailService
{
    Task SendMessageAsync(string from, string to, string subject, string body);
}
