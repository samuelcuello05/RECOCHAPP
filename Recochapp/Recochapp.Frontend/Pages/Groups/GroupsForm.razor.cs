using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using Recochapp.Shared.Entities;

namespace Recochapp.Frontend.Pages.Groups
{
    public partial class GroupsForm
    {
        private EditContext editContext = null!;

        protected override void OnInitialized()
        {
            editContext = new(Group);
        }

        [EditorRequired, Parameter] public Group Group { get; set; } = null!;
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
                Title = "�Est�s seguro?",
                Text = "Perder�s los cambios no guardados.",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonText = "S�, volver",
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
                Title = "�Est�s seguro?",
                Text = "Perder�s los cambios no guardados.",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonText = "S�, volver",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                await ReturnAction.InvokeAsync();
            }
        }

    }
}