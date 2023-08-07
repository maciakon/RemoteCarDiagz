using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using RemoteCarDiagz.Shared.Domain;
using System.Net.Http;
using System.Net.Http.Json;
using RemoteCarDiagz.Shared.Requests;

namespace RemoteCarDiagz.Client.Pages
{
    public partial class ProvisioningComponentBase : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        protected ProvisioningConfiguration configuration = new();


        protected async Task HandleSubmit()
        {
            var response = await HttpClient.PostAsJsonAsync("provisioning", new ProvisioningRequest { GrafanaPublicDashBoardUid = configuration.PublicDashboardUid });
        }

        protected override async Task OnInitializedAsync()
        {
            configuration = await HttpClient.GetFromJsonAsync<ProvisioningConfiguration>("provisioning");
        }
    }
}
