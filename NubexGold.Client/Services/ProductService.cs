using NubexGold.Shared;
using System.Net.Http.Json;
using System.Net.Http;

namespace NubexGold.Client.Services
{
    public class ProductService : IProductService
    {
        private HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public IEnumerable<Product> products { get; set; } = Enumerable.Empty<Product>();

        public async Task CreateProduct(Product NewProduct)
        {
             await httpClient.PostAsJsonAsync("api/products", NewProduct);
            
        }
        public async Task UpdateProduct(Product UpdateProduct)
        {
            await httpClient.PostAsJsonAsync("api/products/Edit", UpdateProduct);



        }
        public async Task DeleteProduct(int id)
        {
            var result = await httpClient.DeleteAsync($"api/products/{id}");
        }

        public async Task<Product> GetProduct(int id)
        {
            var result = await httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
            return result;
        }

        public async Task<IEnumerable<Product>> SearcProduct(string? metal)
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<Product>>($"api/products/search?metal={metal}");
            return result;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            products = await httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/Products");
            return products;
        }
           

        public async Task<ProductDataResult> GetProducts(int page)
        {
            var result = await httpClient.GetFromJsonAsync <ProductDataResult> ($"api/products/page/{page}");
            if (result != null)
            {
                products = result.Products.ToList();

                
            }
            return result;
        }
    }
}
