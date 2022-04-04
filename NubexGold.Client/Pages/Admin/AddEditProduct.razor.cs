using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using AutoMapper;
using NubexGold.Client.Models;

namespace NubexGold.Client.Pages.Admin
{
    public partial class AddEditProduct : ComponentBase
    {
        [Inject]
        public IConditionService conditionService { get; set; }
        [Inject]
        public IProductService productService { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        public Product product { get; set; } = new Product();
        public IEnumerable<Condition> Conditions { get; set; } = new List<Condition>();
        public string Pagetitle { get; set; } = string.Empty;
        public string PageHeader { get; set; } = string.Empty;
        public List<Metal> metal { get; set; }
        public AddEditModel ProductModel { get; set; } = new AddEditModel();
        [Parameter]
        public string Id { get; set; }
        IList<IBrowserFile> files = new List<IBrowserFile>();
        List<ImageFile> filebase64 = new List<ImageFile>();
        public List<string> base64image { get; set; } = new List<string>();
        public string dis { get; set; } = "";
        public bool tax { get; set; } = false;
        public string customstr { get; set; } = "NO";
        public bool MyCondition { get; set; } = false;
        private async Task UploadFilesAsync(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles())
            {
                if(files.Count() >= 3)
                {
                    MyCondition = true;
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
                    if(files.Count() == 3)
                        MyCondition = true;
                }
            }
            if (filebase64 != null)
            {
                
                foreach (var file in filebase64)
                {

                    //base64image = "data:" + file.contentType + ";base64," + @file.base64data;
                    base64image.Add("data:" + file.contentType + ";base64," + @file.base64data);
                    StateHasChanged();
                }
            }
            //TODO upload the files to the server
        }


        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int ProductId);
            if (ProductId != 0 )
            {
                PageHeader = "Edit Product";
                Pagetitle = "Product Edit";
                product = await productService.GetProduct(int.Parse(Id));
     
            }
            else
            {
                PageHeader = "Add Product";
                Pagetitle = "Product Create";
                ProductModel = new AddEditModel
                {
                    ProductId = 1,
                    ModifiedBy = "Admin",
                    ModifiedOn = DateTime.Now
                };
             
            }
            Conditions = await conditionService.GetConditions();
            Mapper.Map( product, ProductModel);
        }

        public Task HandleValidSubmit()
        {
            return Task.CompletedTask;
        }

    }
    public class CustomStringToBoolConverter : BoolConverter<string>
    {

        public CustomStringToBoolConverter()
        {
            SetFunc = OnSet;
            GetFunc = OnGet;
        }

        private string TrueString = "Yes";
        private string FalseString = "NO";
        private string NullString = "N/A";

        private string OnGet(bool? value)
        {
            try
            {
                return (value == true) ? TrueString : FalseString;
            }
            catch (Exception e)
            {
                UpdateGetError("Conversion error: " + e.Message);
                return NullString;
            }
        }

        private bool? OnSet(string arg)
        {
            if (arg == null)
                return null;
            try
            {
                if (arg == TrueString)
                    return true;
                if (arg == FalseString)
                    return false;
                else
                    return null;
            }
            catch (FormatException e)
            {
                UpdateSetError("Conversion error: " + e.Message);
                return null;
            }
        }

    }
    
}
