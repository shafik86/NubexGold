using AutoMapper;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;
//using static MudBlazor.CategoryTypes;

namespace NubexGold.Client.Pages.Admin
{
    public partial class ProductList : ComponentBase
    {
        public string Pagetitle { get; set; } = "List Of Product";
        public string Title { get; set; } = "All List Product";
        [Inject]
        public IConditionService conditionService { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        [Inject]
        public NavigationManager navigation { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        private List<string> editEvents = new();
        private bool dense = false;
        private bool hover = true;
        private bool ronly = false;
        private bool canCancelEdit = false;
        private bool blockSwitch = false;
        private string searchString = "";
        private Product selectedItem1 = null;
        private Product elementBeforeEdit;
        private HashSet<Product> selectedItems1 = new HashSet<Product>();

        //private IEnumerable<Product> Elements = new List<Product>();

        protected override async Task OnInitializedAsync()
        {
            var result = await productService.GetAllProducts();
            if (result != null)
            {
                Products = result;
            }
        }

        private void ClearEventLog()
        {
            editEvents.Clear();
        }

        private void AddEditionEvent(string message)
        {
            editEvents.Add(message);
            StateHasChanged();
        }

        private void BackupItem(object element)
        {
            elementBeforeEdit = new()
            {
                ProductSKU = ((Product)element).ProductSKU,
                ProductName = ((Product)element).ProductName,
                Detail = ((Product)element).Detail,
                Weight = ((Product)element).Weight,
                MetalWeight = ((Product)element).MetalWeight
            };
            AddEditionEvent($"RowEditPreview event: made a backup of Element {((Product)element).ProductName}");
        }

        private void ItemHasBeenCommitted(object element)
        {
            AddEditionEvent($"RowEditCommit event: Changes to Element {((Product)element).ProductName} committed");
        }

        private void ResetItemToOriginalValues(object element)
        {
            ((Product)element).ProductSKU = elementBeforeEdit.ProductSKU;
            ((Product)element).ProductName = elementBeforeEdit.ProductName;
            ((Product)element).Detail = elementBeforeEdit.Detail;
            ((Product)element).Weight = elementBeforeEdit.Weight;
            AddEditionEvent($"RowEditCancel event: Editing of Element {((Product)element).ProductName} cancelled");
        }

        private bool FilterFunc(Product element)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.ProductSKU.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{element.Detail} {element.Metal} {element.Type}".Contains(searchString))
                return true;
            return false;
        }
    }
}
