using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace NubexGold.Client.Pages.Admin
{
    public partial class Roles : ComponentBase
    {
        [Inject]
        public HttpClient httpClient { get; set; }
        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private RoleResponse selectedItem1 = null;
        private HashSet<RoleResponse> selectedItems = new HashSet<RoleResponse>();

        private IEnumerable<RoleResponse> _roleList = new List<RoleResponse>();

        protected override async Task OnInitializedAsync()
        {
            _roleList = await httpClient.GetFromJsonAsync<List<RoleResponse>>("api/products");
        }

        private bool FilterFunc1(RoleResponse Users) => FilterFunc(Users, searchString1);

        private bool FilterFunc(RoleResponse _roleList, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (_roleList.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (_roleList.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{_roleList.Name} {_roleList.Description} ".Contains(searchString))
                return true;
            return false;
        }
    }
}
