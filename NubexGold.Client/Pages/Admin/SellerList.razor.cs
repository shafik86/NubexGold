using AutoMapper;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace NubexGold.Client.Pages.Admin
{
    public partial class SellerList : ComponentBase
    {

        [Inject]
        public ISnackbar snackbar { get; set; }
        public string Pagetitle { get; set; } = "Seller Info";
        public string Title { get; set; } = "Seller List Info";
        //[Inject]
        //public IConditionService conditionService { get; set; }
        [Inject]
        public ISellerService? sellerService { get; set; }

        public IEnumerable<Seller> Sellers { get; set; }
        [Inject]
        public IMapper? Mapper { get; set; }
        [Inject]
        public NavigationManager? navigation { get; set; }
        private List<string> editEvents = new();
        private bool dense = false;
        private bool hover = true;
        private bool ronly = false;
        private bool canCancelEdit = false;
        private bool blockSwitch = false;
        private string searchString = "";
        private Seller selectedItem1 = null;
        private Seller? elementBeforeEdit;
        private HashSet<Seller> selectedItems1 = new HashSet<Seller>();

        //private IEnumerable<Element> Elements = new List<Element>();

        protected override async Task OnInitializedAsync()
        {
            Sellers = await sellerService.GetSellers();
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
                SellerEmail = ((Seller)element).SellerEmail,
                SellerName = ((Seller)element).SellerName,
                SellerContact = ((Seller)element).SellerContact,
                SellerAddress = ((Seller)element).SellerAddress
            };
            AddEditionEvent($"RowEditPreview event: made a backup of Element {((Seller)element).SellerName}");
        }

        private void ItemHasBeenCommitted(object element)
        {
            AddEditionEvent($"RowEditCommit event: Changes to Element {((Seller)element).SellerName} committed");
        }

        private void ResetItemToOriginalValues(object element)
        {
            ((Seller)element).SellerEmail = elementBeforeEdit.SellerEmail;
            ((Seller)element).SellerName = elementBeforeEdit.SellerName;
            ((Seller)element).SellerContact = elementBeforeEdit.SellerContact;
            ((Seller)element).SellerAddress = elementBeforeEdit.SellerAddress;
            AddEditionEvent($"RowEditCancel event: Editing of Element {((Seller)element).SellerName} cancelled");
        }

        private bool FilterFunc(Seller seller)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (seller.SellerEmail.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (seller.SellerName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{seller.SellerAddress} {seller.SellerContact} {seller.SellerCompany}".Contains(searchString))
                return true;
            return false;
        }
    }
}
