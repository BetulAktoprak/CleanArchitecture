using CleanArchitecture.Infrastructure.Extensions;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.WebAPI.Configurations;
using CleanArchitecture.WebAPI.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.InstallService(builder.Configuration, builder.Host, typeof(IServiceInstaller).Assembly);

builder.Services.AddEmailServices();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scoped = app.Services.CreateScope())
{
    AppDbContext context = scoped.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

app.Run();
