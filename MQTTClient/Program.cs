using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using System.Text.Json;


// Create the client object
IManagedMqttClient _mqttClient = new MqttFactory().CreateManagedMqttClient();

// Create client options object
MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                                        .WithClientId("behroozbc")
                                        .WithTcpServer("localhost");
ManagedMqttClientOptions options = new ManagedMqttClientOptionsBuilder()
                        .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                        .WithClientOptions(builder.Build())
                        .Build();



// Set up handlers
_mqttClient.ConnectedAsync += new Func<MqttClientConnectedEventArgs, Task>((e) => { Console.WriteLine("Connected"); return Task.CompletedTask; });
_mqttClient.DisconnectedAsync += new Func<MqttClientDisconnectedEventArgs, Task>((e) => { Console.WriteLine("Disconnected"); return Task.CompletedTask; });
_mqttClient.ConnectingFailedAsync += new Func<ConnectingFailedEventArgs, Task>((e) =>
{
    Console.WriteLine("Connection failed check network or broker!");
    return Task.CompletedTask;
});

// Connect to broker
await _mqttClient.StartAsync(options);

// Send a new message to the broker every second
while (true)
{
    string json = JsonSerializer.Serialize(new { message = "Hi Mqtt", sent = DateTime.UtcNow });
    await _mqttClient.EnqueueAsync("behroozbc.ir/topic/json", json);

    await Task.Delay(TimeSpan.FromSeconds(1));
}