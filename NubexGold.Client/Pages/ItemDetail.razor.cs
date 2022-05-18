



using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

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
        [Inject]
        public ISnackbar snackbar { get; set; }
        public Product product { get; set; } = new Product();
        public bool loading { get; set; } = true;
        [Parameter]
        public string Id { get; set; }
        public string TimeRemaining { get; set; } = "12h 10m 59s";
        public string ImageHead { get; set; } = string.Empty;
        public int spacing { get; set; } = 2;
        public string message { get; set; }= string.Empty;
        public string Conds { get; set; } = string.Empty ;
        public double Weight { get; set; } = 0;
        public string From { get; set; } = "Nubex";
        public int Qty { get; set; } = 0;
        public string btncheck { get; set; } = "Disabled";
        public string x { get; set; } = string.Empty;

        // Object & var for price changing
        [Inject]
        protected IPriceService priceService { get; set; }
        public Prices prices { get; set; }
        public int Apis { get; set; } = 0;
        public int counter { get; set; } = 0;
        public golds myrPrice { get; set; } = new golds();
        public string Errormessage { get; set; }
        public bool IsRunning { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            prices = new Prices();
            var auth = await authenticationStateTask;
            if (!auth.User.Identity.IsAuthenticated)
            {
                //navigation.NavigateTo("Identity/Account/Login");
                message = "Not Login";
                snackbar.Add(message, Severity.Info);
            }
            
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
            
            StateHasChanged();

            SyncPrice();
        }

        public async void SyncPrice()
        {
            var apiCalled = 0;
            while (IsRunning)
            {
                try
                {
                    myrPrice = await priceService.getAllPrice();
                    prices.goldPrice_Myr = myrPrice.gold.price / (decimal)31.1035;
                    prices.silverPrice_Myr = myrPrice.silver.price / (decimal)31.1035;
                    StateHasChanged();
                    var x = 3500;
                    counter += x;
                    apiCalled += 1;
                    //###########################################
                    
                        product.Price = Math.Round(((double)prices.goldPrice_Myr * product.Weight), 2);
                   
                    //###########################################
                    Apis = apiCalled;
                    StateHasChanged();
                    CheckTime();
                    await Task.Delay(x);
                    StateHasChanged();
                }
                catch (Exception e)
                {
                    message = "Price Unable to update at times " + Apis.ToString();
                    snackbar.Add(message, Severity.Error);
                    
                    StateHasChanged();
                    await Task.Delay(30000);
                    counter += 30000;
                    prices.goldPrice_Myr = 0;
                    prices.silverPrice_Myr = 0;
                    snackbar.Add("Restarting updating Price !", Severity.Info);
                }
            }
            snackbar.Add("Dah Stop!!!", Severity.Error);
            //message = string.Empty;

        }
        void CheckTime()
        {
            if (counter >= 600000)
            {
                IsRunning = false;
                message = "Page is idle for 10 Minutes. Please refresh to get current Price";

                StateHasChanged();
            }
        }
        public void AddToCart(int Id)
        {
            message = $"Click success for Id : {Id}";
            
            //navigation.NavigateTo("/shoppingcart", true);
           snackbar.Add(message, Severity.Success);
        }
        void SelectionChanged(ChangeEventArgs args)
        {
            x = args.Value.ToString();
            if (!string.IsNullOrEmpty(x))
            {
                btncheck = string.Empty;
            }
        }
    }
}
