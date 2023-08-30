using MQTTnet.AspNetCore;
using RemoteCarDiagz.MqttBroker.Mqtt;

namespace RemoteCarDiagz.MqttBroker
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMqttController controller)
        {
            app.UseRouting();
            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapConnectionHandler<MqttConnectionHandler>(
                        "/mqtt",
                        httpConnectionDispatcherOptions => httpConnectionDispatcherOptions.WebSockets.SubProtocolSelector =
                            protocolList => protocolList.FirstOrDefault() ?? string.Empty);
                });

            app.UseMqttServer(
                server =>
                {
                    /*
                     * Attach event handlers etc. if required.
                     */
#if DEBUG
                    server.InterceptingPublishAsync += controller.InterceptPublishAsync;
                    server.InterceptingSubscriptionAsync += controller.InterceptSubscriptionAsync;
                    server.InterceptingInboundPacketAsync += controller.InterceptingInboundPacketAsync;
                    server.ValidatingConnectionAsync += controller.ValidateConnection;
                    server.ClientConnectedAsync += controller.OnClientConnected;
#endif
                });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedMqttServer(
                optionsBuilder =>
                {
                    optionsBuilder.WithDefaultEndpoint();
                });

            services.AddMqttConnectionHandler();
            services.AddConnections();

            services.AddSingleton<IMqttController, MqttController>();
        }
    }
}
