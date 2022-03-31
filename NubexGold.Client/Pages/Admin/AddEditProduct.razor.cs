using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace NubexGold.Client.Pages.Admin
{
    public partial class AddEditProduct : ComponentBase
    {
        public string Pagetitle { get; set; } = string.Empty;
        public string PageHeader { get; set; } = string.Empty;
        public AddEditModel ProductModel { get; set; } = new AddEditModel();
        [Parameter]
        public string Id { get; set; }
        IList<IBrowserFile> files = new List<IBrowserFile>();
        private void UploadFiles(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles())
            {
                files.Add(file);
            }
            //TODO upload the files to the server
        }


        protected override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int ProductId);
            if (ProductId == null)
            {
                ProductModel = new AddEditModel
                {
                    ProductId = 0,
                };

            }
            return base.OnInitializedAsync();
        }

        public Task HandleValidSubmit()
        {
            return Task.CompletedTask;
        }
    }
}
