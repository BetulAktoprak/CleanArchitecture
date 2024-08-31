using CleanArchitecture.Application.Services;
using FluentEmail.Core;

namespace CleanArchitecture.Infrastructure.Services;
public sealed class MailService : IMailService
{
    private readonly IFluentEmail _fluentEmail;

    public MailService(IFluentEmail fluentEmail)
    {
        _fluentEmail = fluentEmail;
    }

    public async Task SendMailAsync(string to, string subject, string body)
    {
        var result = await _fluentEmail
            .To(to)
            .Subject(subject)
            .Body(body)
            .SendAsync();

        if (!result.Successful)
        {
            throw new Exception("Email gönderimi başarısız oldu");
        }
    }
}
