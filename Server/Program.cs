using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Extensions.ManagedClient;
using RemoteCarDiagz.Server.Data;
using RemoteCarDiagz.Server.Extensions;
using RemoteCarDiagz.Server.Mqtt;
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
                    .AddSingleton<IConfigurationMqttClient, ConfigurationMqttClient>()
                    .AddSingleton<IMeasurementsMqttClient, MeasurementsMqttClient>()
                    .AddSingleton(provider =>
                    {

                        IManagedMqttClient _mqttClient = new MqttFactory().CreateManagedMqttClient();
                        // Create client options object
                        return _mqttClient;
                    })
                    .AddHostedService<MqttClientHostedService>());
    }
}
