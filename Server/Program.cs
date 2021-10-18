using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RemoteCarDiagz.Server.Data;
using RemoteCarDiagz.Server.Extensions;
using RemoteCarDiagz.Server.Services;

namespace RemoteCarDiagz.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase<RemoteCarDiagzContext>().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(
                    (_, services) => 
                    services
                    .AddScoped<IMeasurementService, MeasurementService>()
                    .AddScoped<IConfigurationService, ConfigurationService>()
                    );
    }
}
