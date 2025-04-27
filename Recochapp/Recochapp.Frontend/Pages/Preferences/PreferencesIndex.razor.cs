using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Recochapp.Frontend.Repositories;
using Recochapp.Shared.Entities;

namespace Recochapp.Frontend.Pages.Preferences
{
    public partial class PreferencesIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        private List<Preference>? Preferences { get; set; }
        private List<UserPreference>? UserPreferences { get; set; }

        private List<Establishment>? Establishments { get; set; }
        [Parameter] public int Id { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task LoadAsync()
        {
            var responseHppt = await Repository.GetAsync<List<Preference>>("api/preferences");
            if (responseHppt.Error)
            {
                var message = await responseHppt.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("ErrorIndex", message, SweetAlertIcon.Error);
                return;
            }
            Preferences = responseHppt.Response;
            if (Preferences == null || !Preferences.Any())
            {
                await SweetAlertService.FireAsync("Alerta", "No hay preferencias disponibles.", SweetAlertIcon.Warning);
            }

            //var responseEstablishments = await Repository.GetAsync<List<Establishment>>("api/establishments");
            //if (responseEstablishments.Error)
            //{
            //    var message = await responseEstablishments.GetErrorMessageAsync();
            //    await SweetAlertService.FireAsync("ErrorIndex", message, SweetAlertIcon.Error);
            //    return;
            //}
            //Establishments = responseEstablishments.Response;
        }
    }
}