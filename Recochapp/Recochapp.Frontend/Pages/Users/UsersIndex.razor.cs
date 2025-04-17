using Microsoft.AspNetCore.Components;
using Recochapp.Frontend.Repositories;
using Recochapp.Shared.Entities;

namespace Recochapp.Frontend.Pages.Users
{
    public partial class UsersIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;

        private List<User>? Users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await Repository.GetAsync<List<User>>("api/Users");
            Users = responseHttp.Response;
        }
    }
}