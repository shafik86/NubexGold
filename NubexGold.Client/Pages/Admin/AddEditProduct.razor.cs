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
        List<ImageFile> filebase64 = new List<ImageFile>();
        public string base64image { get; set; } = string.Empty;
        public string pic1 { get; set; }
        public string pic2 { get; set; }
        public string pic3 { get; set; }


        private async Task UploadFilesAsync(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles())
            {
                if(files.Count() >= 3)
                {
                    return;
                }
                else
                {
                    files.Add(file);
                    var resizedFile = await file.RequestImageFileAsync(file.ContentType, 640, 480);
                    var buf = new byte[resizedFile.Size];
                    using (var stream = resizedFile.OpenReadStream())
                    {
                        await stream.ReadAsync(buf);
                    }
                    filebase64.Add(new ImageFile
                    {
                        base64data = Convert.ToBase64String(buf),
                        contentType = file.ContentType,
                        fileName = file.Name
                    });
                    
                }
            }
            if (filebase64 != null)
            {
                var x = 0;
                foreach (var file in filebase64)
                {
                    x++;
                    base64image = "data:" + file.contentType + ";base64," + @file.base64data;
                    switch(x)
                    {
                        case 1:
                            pic1 = base64image;
                            break;
                        case 2:
                            pic2 = base64image;
                            break;
                        case 3:
                            pic3 = base64image;
                            break;
                        default:
                            break;
                    }

                    StateHasChanged();
                }
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
