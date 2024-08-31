namespace CleanArchitecture.Application.Services;
public interface IMailService
{
    Task SendMailAsync(string to, string subject, string body);

}
