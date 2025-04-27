using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Recochapp.Frontend.Repositories;
using Recochapp.Shared.Entities;

namespace Recochapp.Frontend.Pages.Plans
{
    public partial class PlansIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
        [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

        private List<Plan>? Plans { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task LoadAsync()
        {
            var responseHppt = await Repository.GetAsync<List<Plan>>("api/plans");
            if (responseHppt.Error)
            {
                var message = await responseHppt.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("ErrorIndex", message, SweetAlertIcon.Error);
                return;
            }
            Plans = responseHppt.Response;
            if (Plans == null || !Plans.Any())
            {
                await SweetAlertService.FireAsync("Alerta", "No hay planes disponibles.", SweetAlertIcon.Warning);
            }
        }

    }
}