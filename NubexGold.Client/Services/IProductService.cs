using NubexGold.Shared;

namespace NubexGold.Client.Services
{
    public interface IProductService
    {
        IEnumerable<Product> products { get; set; }
        //Task<IEnumerable<Product>> GetProductsMetal(Metal? metal);
        Task<ProductDataResult> GetProducts();
        Task CreateProduct(Product NewProduct);
        Task UpdateProduct(Product UpdateProduct);
        Task<IEnumerable<Product>> SearcProduct(string? metal);
        Task DeleteProduct(int id);
        Task<Product> GetProduct(int id);
    }
}
