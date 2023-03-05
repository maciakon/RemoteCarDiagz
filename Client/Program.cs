using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace RemoteCarDiagz.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            
            // var dockerBaseUrl = builder.HostEnvironment.BaseAddress.Replace("8080", "5001");
            var dockerBaseUrl = "http://server:5001";
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(dockerBaseUrl) });

            await builder.Build().RunAsync();
        }
    }
}
