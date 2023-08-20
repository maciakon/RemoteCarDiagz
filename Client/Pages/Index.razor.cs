using Microsoft.AspNetCore.Components;
using RemoteCarDiagz.Shared.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCarDiagz.Shared.Domain;
using System.Net.Http.Json;
using System.Net.Http;

namespace RemoteCarDiagz.Client.Pages
{
    public class IndexComponentBase : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        protected List<Measurement> activeMeasurements;

        protected string GetButtonState(bool isActive)
        {
            return isActive ? "btn btn-danger" : "btn btn-success";
        }
        protected string GetButtonText(bool isActive)
        {
            return isActive ? "Deactivate" : "Activate";
        }

        protected async Task TogggleMeasurementActive(Measurement measurement)
        {
            measurement.IsActive = !measurement.IsActive;
            var toggleActivationRequest = new ToggleActivateMeasurementRequest { Pid = measurement.Value, IsActive = measurement.IsActive };
            var response = await HttpClient.PostAsJsonAsync("configuration", toggleActivationRequest);
        }

        protected override async Task OnInitializedAsync()
        {
            activeMeasurements = await HttpClient.GetFromJsonAsync<List<Measurement>>("configuration");
        }
    }
}
