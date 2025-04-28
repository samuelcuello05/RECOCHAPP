using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using Recochapp.Shared.Entities;
using Recochapp.Frontend.Repositories;
using Recochapp.Shared.Filters;

namespace Recochapp.Frontend.Pages.Preferences
{
    public partial class PreferencesForm
    {
        private EditContext editContext = null!;

        protected override async Task OnInitializedAsync()
        {
            editContext = new(Preference);
            await LoadEstablecimientosAsync();

        }
        [Inject] private IRepository Repository { get; set; } = null!;
        [EditorRequired, Parameter] public Preference Preference { get; set; } = null!;
        [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
        [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

        private List<Establishment>? Establishments { get; set; }


        public bool FormPostedSuccessfully { get; set; } = false;
        private bool showSelectEstablishmentModal = false;


        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        private async Task LoadEstablecimientosAsync()
        {
            var response = await Repository.GetAsync<List<Establishment>>("api/Establishments");
            if (!response.Error)
            {
                Establishments = response.Response;

                // Aplicar filtros con Strategy
                var context = new EstablishmentFilterContext();
                context.AddStrategy(new CombinedFilterStrategy());

                Establishments = context.ApplyFilters(Establishments, Preference).ToList();
            }
        }

        private async Task SelectEstablishment(int establishmentId)
        {
            Preference.EstablishmentId = establishmentId;
            showSelectEstablishmentModal = false;

            await OnValidSubmit.InvokeAsync();
        }

        private void CloseModal()
        {
            showSelectEstablishmentModal = false;
        }

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formWasEdited = editContext.IsModified();

            if (!formWasEdited || FormPostedSuccessfully)
            {
                return;
            }

            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Cuidado",
                Text = "¿Desea regresar si guardar los cambios?",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true
            });

            var confirm = !string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }

            context.PreventNavigation();
        }

        private async Task OnFormValidSubmit()
        {
            await LoadEstablecimientosAsync();
            showSelectEstablishmentModal = true; // Abrir modal para seleccionar establecimiento
            await InvokeAsync(StateHasChanged);
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

        public async Task OpenSelectEstablishmentModal()
        {
            showSelectEstablishmentModal = true;
            await InvokeAsync(StateHasChanged);
        }

    }
}