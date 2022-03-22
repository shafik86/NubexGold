using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using NubexGold.Client.Services;
using NubexGold.Shared;

namespace NubexGold.Client.Pages.Shopping
{
    public partial class AllProducts : ComponentBase
    {
        [CascadingParameter]
        public Task<AuthenticationState> authenticationState { get; set; }
        [Inject]
        public NavigationManager navigation { get; set; }
        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public string Metal { get; set; }
        [Parameter]
        public string type { get; set; }
        [Inject]
        public IProductService? ProductServices { get; set; }


        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public bool Loading { get; set; } = true;
        public string PageHeader { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var auth = await authenticationState;

            if (!auth.User.Identity.IsAuthenticated)
            {
                navigation.NavigateTo("authentication/login");
            }
            //Products = await ProductServices.GetProducts();
            //Loading = false;

            //return base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            Loading = true;
            Products = new List<Product>();
            var auth = await authenticationState;
            if (!auth.User.Identity.IsAuthenticated)
            {
                navigation.NavigateTo("authentication/login");
            }
            else
            {
                int[] m = new int[] { 0, 1, 3 };
                if (Metal != string.Empty || Metal != "")
                {

                    PageHeader = "Products " + Metal;
                    Products = await ProductServices.SearcProduct(Metal, type);
                    StateHasChanged();
                    Loading = false;

                    if (Id != string.Empty || Id != "")
                    {
                        int.TryParse(Id, out int ProductId);
                        PageHeader += Id;
                        StateHasChanged();
                    }
                }
                else
                {
                    Products = await ProductServices.GetProducts();
                    Loading = false;
                    StateHasChanged();
                }
            }

        }
    }
}
