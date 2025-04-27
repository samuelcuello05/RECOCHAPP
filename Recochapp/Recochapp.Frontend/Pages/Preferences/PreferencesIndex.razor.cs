using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Recochapp.Frontend.Repositories;
using Recochapp.Shared.Entities;
using System.Numerics;

namespace Recochapp.Frontend.Pages.Preferences
{
    public partial class PreferencesIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        private List<Preference>? Preferences { get; set; }
        private Plan? Plan { get; set; }
        private List<Establishment>? Establishments { get; set; }
        private List<UserPreference>? UserPreferences { get; set; }

        [Parameter] public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task LoadAsync()
        {
            var responseHttpPlan = await Repository.GetAsync<Plan>($"api/plans/{Id}");
            if (responseHttpPlan.Error)
            {
                var message = await responseHttpPlan.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("ErrorIndex", message, SweetAlertIcon.Error);
                return;
            }

            var plan = responseHttpPlan.Response;

            if (plan == null)
            {
                await SweetAlertService.FireAsync("Alerta", "No se encontró el plan solicitado.", SweetAlertIcon.Warning);
            }
            else
            {
                Plan = plan ;
            }

            var responseHttpUserPreferences = await Repository.GetAsync<List<UserPreference>>("api/userpreferences");
            if (responseHttpUserPreferences.Error)
            {
                var message = await responseHttpUserPreferences.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("ErrorIndex", message, SweetAlertIcon.Error);
                return;
            }

            UserPreferences = responseHttpUserPreferences.Response?.Where(up => up.PlanId == Id).ToList();

            if (UserPreferences == null || !UserPreferences.Any())
            {
                await SweetAlertService.FireAsync("Alerta", "No hay preferencias disponibles para este plan.", SweetAlertIcon.Warning);
            }


            var responseHttpPreferences = await Repository.GetAsync<List<Preference>>("api/preferences");
            if (responseHttpPreferences.Error)
            {
                var message = await responseHttpPreferences.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("ErrorIndex", message, SweetAlertIcon.Error);
                return;
            }

            var preferenceIds = UserPreferences?.Select(up => up.PreferenceId).ToList();

            Preferences = responseHttpPreferences?.Response?.Where(p => preferenceIds.Contains(p.Id)).ToList();

            if (Preferences == null || !Preferences.Any())
            {
                await SweetAlertService.FireAsync("Alerta", "No hay preferencias disponibles.", SweetAlertIcon.Warning);
            }



            var responseHttpEstablishments = await Repository.GetAsync<List<Establishment>>("api/establishments");
            if (responseHttpEstablishments.Error)
            {
                var message = await responseHttpEstablishments.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("ErrorIndex", message, SweetAlertIcon.Error);
                return;
            }

            var establishmentIds = Preferences?.Select(up => up.EstablishmentId).ToList();

            Establishments = responseHttpEstablishments.Response?.Where(est => establishmentIds.Contains(est.Id)).ToList();

            if (Establishments == null || !Establishments.Any())
            {
                await SweetAlertService.FireAsync("Alerta", "No se encontraron establecimientos registrados.", SweetAlertIcon.Warning);
            }

        }

    }
}