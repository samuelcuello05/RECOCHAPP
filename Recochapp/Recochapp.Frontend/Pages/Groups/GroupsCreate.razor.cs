using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Recochapp.Frontend.Pages.Groups;
using Recochapp.Frontend.Repositories;
using Recochapp.Shared.Entities;

namespace Recochapp.Frontend.Pages.Groups
{
    public partial class GroupsCreate
    {
        private GroupsForm? GroupsForm;
        private Group Group = new();

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        private async Task CreateAsync()
        {
            var responseHttp = await Repository.PostAsync("/api/Groups", Group);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message);
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
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Grupo creado con éxito");
        }

        private void Return()
        {
            GroupsForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("/Groups");
        }

    }
}