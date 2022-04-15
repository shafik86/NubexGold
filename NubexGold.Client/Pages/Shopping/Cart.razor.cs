using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazor;
using NubexGold.Client.Services.UserCartServices;
//using Microsoft.AspNetCore.Components.Authorization.AuthenticationState
using NubexGold.Client.Areas.Identity.Pages.Account.Manage;

namespace NubexGold.Client.Pages.Shopping
{
    public partial class Cart : ComponentBase
    {
        [CascadingParameter]
        public Task<AuthenticationState> authenticationStateTask { get; set; }
        [Inject]
        public IUserCartService userCartService { get; set; }
        //[Inject]
        //public AuthenticationState context { get; set; }
        //public readonly IdentityUser identityUser;
        [Inject]
        public ISnackbar snackbar { get; set; }
        public List<Orders> orders { get; set; }
        public ItemCart UserCartItems { get; set; } = new ItemCart();

        protected override async Task OnInitializedAsync()
        {
            string UsrId = "df309e1a-b7eb-49b3-aa91-a27b565e4374".ToString();
            //var user = await test.GetEmailAsync();
            var result = userCartService.GetAllCarts();

            snackbar.Add(result.ToString());
            //UserCartItems = result; 
            //return base.OnInitializedAsync();
        }



    }
}
