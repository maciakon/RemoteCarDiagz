using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
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
            var dockerBaseUrl = "https://api.remotecardiagz.pl";
#if DEBUG   
            dockerBaseUrl = "https://localhost:5001";
#endif
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(dockerBaseUrl) });

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
            });

            await builder.Build().RunAsync();
        }
    }
}
