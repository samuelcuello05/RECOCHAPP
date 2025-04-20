using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using Recochapp.Shared.Entities;
using System.Net.Http.Json;


namespace Recochapp.Frontend.Pages.Plans
{
    public partial class PlansForm
    {
        [Inject] private HttpClient Http { get; set; } = null!;

        private EditContext editContext = null!;
        private List<Group> Groups = new List<Group>();
        private List<Establishment> Establishments = new List<Establishment>();


        protected override async Task OnInitializedAsync()
        {
            editContext = new(Plan);
            Groups = await Http.GetFromJsonAsync<List<Group>>("api/groups");
            Establishments = await Http.GetFromJsonAsync<List<Establishment>>("api/establishments");
        }

        [EditorRequired, Parameter] public Plan Plan { get; set; } = null!;
        [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
        [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

        public bool FormPostedSuccessfully { get; set; } = false;

        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formWasEdited = editContext.IsModified();

            if (!formWasEdited || FormPostedSuccessfully)
            {
                return;
            }

            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "¿Estás seguro?",
                Text = "Perderás los cambios no guardados.",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonText = "Sí, volver",
                CancelButtonText = "Cancelar"
            });

            var confirm = !string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }

            context.PreventNavigation();
        }
        private async Task ConfirmReturnAsync()
        {
            var formWasEdited = editContext.IsModified();

            if (!formWasEdited || FormPostedSuccessfully)
            {
                await ReturnAction.InvokeAsync();
                return;
            }

            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "¿Estás seguro?",
                Text = "Perderás los cambios no guardados.",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonText = "Sí, volver",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                await ReturnAction.InvokeAsync();
            }
        }
    }
}