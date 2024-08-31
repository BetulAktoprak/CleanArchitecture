using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Mail;

namespace CleanArchitecture.Infrastructure.Extensions;
public static class MailServiceExtensions
{
    public static IServiceCollection AddEmailServices(this IServiceCollection services)
    {
        services.AddFluentEmail("from@example.com")
            .AddRazorRenderer()
            .AddSmtpSender(new SmtpClient("smtp.example.com")
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("", ""),
                EnableSsl = true,
                Port = 587
            });

        services.AddScoped<IMailService, MailService>();

        return services;
    }
}
