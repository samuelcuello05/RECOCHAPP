using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Recochapp.Frontend.Repositories;
using Recochapp.Shared.Entities;
using System.Diagnostics.Metrics;

namespace Recochapp.Frontend.Pages.Users
{
    public partial class UsersEdit
    {
        private User? user;
        private UsersForm? usersForm;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Parameter] public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await Repository.GetAsync<User>($"api/Users/{Id}");

            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("users");
                }
                else
                {
                    var messageError = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", messageError, SweetAlertIcon.Error);
                }
            }
            else
            {
                user = responseHttp.Response;
            }
        }

        private async Task EditAsync()
        {
            var responseHttp = await Repository.PutAsync("api/users", user);

            if (responseHttp.Error)
            {
                var mensajeError = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
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
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Usuario actualizado correctamente");
        }

        private void Return()
        {
            usersForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("users");
        }

    }
}