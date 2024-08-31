using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace CleanArchitecture.WebAPI.Configurations;

public sealed class PersistanceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.AddAutoMapper(typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly);

        string connectionString = configuration.GetConnectionString("SqlServer")!;

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddIdentity<AppUser, Role>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;

        }).AddEntityFrameworkStores<AppDbContext>();


        //using Serilog.Sinks.MSSqlServer;

        var sinkOptions = new MSSqlServerSinkOptions
        {
            TableName = "Logs",
            AutoCreateSqlTable = true,
        };

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.MSSqlServer(
                connectionString: connectionString,
                sinkOptions: sinkOptions
            )
            .CreateLogger();

        //Log.Logger = new LoggerConfiguration()
        //    .MinimumLevel.Information()
        //    .Enrich.FromLogContext()
        //    .WriteTo.Console()
        //    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
        //    .WriteTo.MSSqlServer(
        //     connectionString: connectionString,
        //     tableName: "Logs",
        //     autoCreateSqlTable: true)
        //    .CreateLogger();


        host.UseSerilog();
    }
}
