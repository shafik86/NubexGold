using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using MudBlazor;

namespace NubexGold.Client.Pages.Admin
{
    public partial class Users : ComponentBase
    {
        private int selectedRowNumber = -1;
        public IEnumerable<User> users { get; set; } = new List<User>();
        private List<string> clickedEvents = new();
        public SignInManager<IdentityUser> signIn { get; set; }
        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        public ISnackbar snackbar { get; set; }
        private MudTable<User> mudTable;
        private string searchString1 = "";
        protected override async Task OnInitializedAsync()
        {
            var s = "berjaya";
            snackbar.Add(s);
        }
        private void RowClickEvent(TableRowClickEventArgs<User> tableRowClickEventArgs)
            {
                clickedEvents.Add("Row has been clicked");
            }

            private string SelectedRowClassFunc(User element, int rowNumber)
            {
                if (selectedRowNumber == rowNumber)
                {
                    selectedRowNumber = -1;
                    clickedEvents.Add("Selected Row: None");
                    return string.Empty;
                }
                else if (mudTable.SelectedItem != null && mudTable.SelectedItem.Equals(element))
                {
                    selectedRowNumber = rowNumber;
                    clickedEvents.Add($"Selected Row: {rowNumber}");
                    return "selected";
                }
                else
                {
                    return string.Empty;
                }
            }
        private bool FilterFunc1(User Users) => FilterFunc(Users, searchString1);
        private bool FilterFunc(User element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.UserName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{element.UserId} {element.Name} {element.Email} {element.Phone}".Contains(searchString))
                return true;
            return false;
        }
        private void OpenDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AddUserModal>("Simple Dialog", options);
        }
    }
}
