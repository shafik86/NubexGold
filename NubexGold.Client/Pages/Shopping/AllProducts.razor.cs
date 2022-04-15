using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
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
        public string Metal { get; set; } = string.Empty;
        [Parameter]
        public string page { get; set; } = string.Empty.ToString();
        [Inject]
        public IProductService? ProductServices { get; set; }
        
        public string message { get; set; } = string.Empty;

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public ProductDataResult ProductDataResult { get; set; } = new ProductDataResult();
        public bool Loading { get; set; } = true;
        public string PageHeader { get; set; }
        [Inject]
        public ISnackbar? Snackbar { get; set; }
        public int _selected { get; set; } = 1;
        public int PageCount { get; set; } = 1;
        protected override async Task OnInitializedAsync()
        {
           // Products = await ProductServices.GetAllProducts();

            ProductDataResult =  await ProductServices.GetProducts(_selected);
            Products = ProductDataResult.Products;
            PageCount = ProductDataResult.Count;
            StateHasChanged();

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
                //Products = new List<Product>();
   
            if (!firstRender)
            {
                if (Metal is null)
                {
                    ProductDataResult = await ProductServices.GetProducts(_selected);
                    Products = ProductDataResult?.Products;
                    PageCount = ProductDataResult.Count;
                }

              
                
                StateHasChanged();
            }
            //return base.OnAfterRenderAsync(firstRender);
        }
        protected override async Task OnParametersSetAsync()
        {
            Loading = true;
            IEnumerable<Product> MetalProduct = new List<Product>();
            var result = await ProductServices.SearcProduct(Metal);
            MetalProduct = result;
            message = string.Empty;

            if (Metal != string.Empty || Metal != "")
            {
                PageHeader = "Products " + Metal;
                try
                {
                    var v = MetalProduct.Where(e => e.Metal.ToString() == Metal).ToList();
                    if (v != null)
                    {
                        Products = new List<Product>();
                        Products = v;
                        Loading = false;
                    }
                }
                catch (Exception e)
                {
                    message = e.Message;
                }
                StateHasChanged();

            }



        }


    }
}
