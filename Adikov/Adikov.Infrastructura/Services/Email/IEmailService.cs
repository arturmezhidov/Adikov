namespace Adikov.Infrastructura.Services.Email
{
    public interface IEmailService
    {
        string Send(EmailMessage message);
    }
}