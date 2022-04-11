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
        [Inject]
        public NavigationManager? navigation { get; set; }
        [Inject]
        public ISnackbar? Snackbar{ get; set; }
        public Product? product { get; set; } = new Product();
        public IEnumerable<Condition> Conditions { get; set; } = new List<Condition>();
        public string Pagetitle { get; set; } = string.Empty;
        public string PageHeader { get; set; } = string.Empty;

        public AddEditModel ProductModel { get; set; } = new AddEditModel();
        [Parameter]
        public string Id { get; set; }
        IList<IBrowserFile> files = new List<IBrowserFile>();
        List<ImageFile> filebase64 = new List<ImageFile>();
        public IList<ImageFile> Filebase64set = new List<ImageFile>();
        public List<string> base64image { get; set; } = new List<string>();
        public string dis { get; set; } = "";
        public bool tax { get; set; } = false;
        public string customstr { get; set; } = "NO";
        public bool MyCondition { get; set; } = false;
        public string message { get; set; } = string.Empty;
        public int counting { get; set; }=0;
        public string btnSubmit { get; set; } = "Create";
        private async Task UploadFilesAsync(InputFileChangeEventArgs e)
        {
            counting += e.FileCount;
            
            foreach (var file in e.GetMultipleFiles())
            {
               
                
                    files.Add(file);
                    var resizedFile = await file.RequestImageFileAsync(file.ContentType, 500,300);
                    var buf = new byte[resizedFile.Size];
                    using (var stream = resizedFile.OpenReadStream())
                    {
                    
                        var result = await stream.ReadAsync(buf);
                        await Task.Delay(1000);

                        var i = Task.Run(() =>
                        {

                            filebase64.Add(new ImageFile
                            {
                                ImageId = counting,
                                base64data = Convert.ToBase64String(buf),
                                contentType = file.ContentType,
                                fileName = file.Name,
                                Size = file.Size.ToString()

                            });
                        Snackbar.Add("siap image " + counting, Severity.Success);
                        });
                    }
                
            if (filebase64 != null)
            {
                foreach (var ifile in filebase64)
                {

                    //base64image = "data:" + file.contentType + ";base64," + @file.base64data;
                    base64image.Add("data:" + ifile.contentType + ";base64," + ifile.base64data);
                    if (ifile.ImageId == 1)
                    {
                        ProductModel.Image1 = ("data:" + ifile.contentType + ";base64," + ifile.base64data);
                            StateHasChanged();
                        }
                    if (ifile.ImageId == 2)
                    {
                        ProductModel.Image2 = ("data:" + ifile.contentType + ";base64," + ifile.base64data);
                            StateHasChanged();
                        }
                    if (ifile.ImageId == 3)
                    {
                        ProductModel.Image3 = ("data:" + ifile.contentType + ";base64," + ifile.base64data);
                            StateHasChanged();
                        }
                    StateHasChanged();
                }
            }
                    StateHasChanged();
            }
            //TODO upload the files to the server
            if (counting == 3)
            {
                MyCondition = true;
                return;
            }
            StateHasChanged();
        }
        void DelClick(string name)
        {
            int.TryParse(name, out int c);
            
            var result = filebase64.FirstOrDefault(e => e.ImageId == c);
            //if (result != null)
            //    filebase64.Remove(result);
            switch (c)
            {
                case 1: ProductModel.Image1 = null;
                    StateHasChanged();
                    break; 
                case 2: ProductModel.Image2 = null;
                    StateHasChanged();
                    break;
                case 3: ProductModel.Image3 = null;
                    StateHasChanged();
                    break;
                default: break;
            }
            StateHasChanged();
            MyCondition = false;
            if (counting >= 1)
            {
                //files.RemoveAt(counting);
                counting -= 1;
            }
            else
            {
                counting = 0;
            }
            //filebase64.Clear();
            //base64image = "";
        }
 
        protected override async Task OnInitializedAsync()
        {

            if (counting == 3)
            {
                MyCondition = true;
            }
            int.TryParse(Id, out int ProductId);
            if (ProductId != 0 )
            {
                PageHeader = "Edit Product";
                Pagetitle = "Product Edit";
                btnSubmit = "Update";
                try
                {
                    product = await productService.GetProduct(int.Parse(Id));
                    if (product == null)
                    {
                        navigation.NavigateTo("product");
                    }
                }
                catch (Exception)
                {
                    message = $"Prduct with id {ProductId} is not found";
                    
                }
                
            }
            else
            {
                PageHeader = "Add Product";
                Pagetitle = "Product Create";
                btnSubmit = "Create";
                ProductModel = new AddEditModel
                {
                    ProductId = 0,
                    ModifiedBy = "Admin",
                    ModifiedOn = DateTime.Now
                };
             
            }
            Conditions = await conditionService.GetConditions();
            Mapper.Map( product, ProductModel);
        }
        void selet()
        {
            var m = ProductModel.Image2;
            Snackbar.Add(m, Severity.Success);
            StateHasChanged();
        }
        public async void OnValidSubmit()
        {
            product = new Product();
                Mapper.Map(ProductModel, product);
            Product result = product;
            if (product.ProductId != 0)
            {
                //btnSubmit = "Update";
                 await productService.UpdateProduct(product);
                message = $"Product {product.ProductName} Updated";
                navigation.NavigateTo($"/product/{product.ProductId}");
                
                //Snackbar.Add(message, Severity.Info);
                //return;
            }
            else
            {
                //btnSubmit = "Create";
                await productService.CreateProduct(product);
                message = $"Product {product.ProductName} Added";
                Snackbar.Add(message, Severity.Info);
                navigation.NavigateTo($"/product/{product.ProductId}");
                //return;
            }
            //message = "Product with Id : " + Id + " Is updated";
            //Snackbar.Add(message,Severity.Normal);
            StateHasChanged();
            //return Task.CompletedTask;
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
