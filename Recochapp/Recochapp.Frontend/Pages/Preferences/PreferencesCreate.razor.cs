using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Recochapp.Frontend.Pages.Preferences;
using Recochapp.Frontend.Repositories;
using Recochapp.Shared.Entities;

namespace Recochapp.Frontend.Pages.Preferences
{
    public partial class PreferencesCreate
    {
        private PreferencesForm? PreferencesForm;
        private Preference Preference = new();

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Parameter] public int Id { get; set; }

        private async Task CreateAsync()
        {
            var responseHttp = await Repository.PostAsync<Preference, Preference>("/api/Preferences", Preference);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message);
                return;
            }

            var createdPreference = responseHttp.Response!;

            var userPreference = new UserPreference
            {
                PlanId = Id,
                PreferenceId = createdPreference.Id
            };

            var relationResponse = await Repository.PostAsync("/api/UserPreferences", userPreference);
            if (relationResponse.Error)
            {
                var message = await relationResponse.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error al guardar relación", message);
                return;
            }

            Return();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Preferencias seleccionadas con éxito");
        }

        private void Return()
        {
            PreferencesForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("/Plans");
        }
    }
}
