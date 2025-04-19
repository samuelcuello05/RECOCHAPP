using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Recochapp.Frontend.Repositories;
using Recochapp.Shared.Entities;
using System.Diagnostics.Metrics;

namespace Recochapp.Frontend.Pages.Users
{
    public partial class UsersIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        private List<User>? Users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task LoadAsync()
        {
            var responseHppt = await Repository.GetAsync<List<User>>("api/users");
            if (responseHppt.Error)
            {
                var message = await responseHppt.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("ErrorIndex", message, SweetAlertIcon.Error);
                return;
            }
            Users = responseHppt.Response!;
        }

        private async Task DeleteAsync(User user)
        {
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = string.Format("¿Está seguro de que desea eliminar el usuario?", "Usuario", user.Name),
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                CancelButtonText = "Cancelar"
            });

            var confirm = string.IsNullOrEmpty(result.Value);

            if (confirm)
            {
                return;
            }

            var responseHttp = await Repository.DeleteAsync($"api/users/{user.Id}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    var mensajeError = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
                }
                return;
            }

            await LoadAsync();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000,
                ConfirmButtonText = "Listo"
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Usuario eliminado correctamente");
        }

    }
}