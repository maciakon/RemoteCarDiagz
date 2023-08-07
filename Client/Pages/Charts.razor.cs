using Microsoft.AspNetCore.Components;
using RemoteCarDiagz.Shared.Domain;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RemoteCarDiagz.Client.Pages
{
    public class ChartsComponentBase : ComponentBase
    {
        protected ProvisioningConfiguration _configuration;

        protected string GrafanaUrl => $"https://grafana.remotecardiagz.pl/public-dashboards/{_configuration.PublicDashboardUid}";

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _configuration = await HttpClient.GetFromJsonAsync<ProvisioningConfiguration>("provisioning");
        }
    }
}
