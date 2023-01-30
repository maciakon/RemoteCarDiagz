using MQTTnet.AspNetCore;

namespace RemoteCarDiagz.MqttBroker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(Array.Empty<string>())
             .ConfigureWebHostDefaults(
                 webBuilder =>
                 {
                     webBuilder.UseKestrel(
                         o =>
                         {
                             // This will allow MQTT connections based on TCP port 1883.
                             o.ListenAnyIP(1883, l => l.UseMqtt());

                             // This will allow MQTT connections based on HTTP WebSockets with URI "localhost:5000/mqtt"
                             // See code below for URI configuration.
                             o.ListenAnyIP(5000); // Default HTTP pipeline
                         });

                     webBuilder.UseStartup<Startup>();
                 });

            host.Build().Run();
        }
    }
}