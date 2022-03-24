



using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace NubexGold.Client.Pages
{
    public partial class ItemDetail : ComponentBase
    {
        [CascadingParameter]
        public Task<AuthenticationState> authenticationStateTask { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        [Inject]
        public IConditionService conditionService { get; set; }
        [Inject]
        public NavigationManager navigation { get; set; }
        public Product product { get; set; } = new Product();
        public bool loading { get; set; } = true;
        [Parameter]
        public string Id { get; set; }
        public string TimeRemaining { get; set; } = "12h 10m 59s";
        public string ImageHead { get; set; } = string.Empty;
        public int spacing { get; set; } = 2;
        //public string TextValue { get; set; }
        //public double currentprice { get; set; } = 2000;
        //public double BidTotal { get; set; } = 0;
        //public double grandtotal { get; set; } = 0;
        //public double userbid { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var auth = await authenticationStateTask;
            if (!auth.User.Identity.IsAuthenticated)
            {
                navigation.NavigateTo("Identity//login");
            }
            else
            {
                int.TryParse(Id, out int productId);
                try
                {
                    if (productId != 0)
                    {
                        product = await productService.GetProduct(int.Parse(Id));
                        ImageHead = product.Image1;
                        loading = false;
                        StateHasChanged();
                    }
                }
                catch (Exception)
                {

                    string message = "Tiada product id : " + Id;
                }
            }
            StateHasChanged();
        }
    }
}
