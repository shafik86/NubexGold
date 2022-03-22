using NubexGold.Shared;

namespace NubexGold.Client.Services
{
    public interface IProductService
    {
        IEnumerable<Product> products { get; set; }
        //Task<IEnumerable<Product>> GetProductsMetal(Metal? metal);
        Task<IEnumerable<Product>> GetProducts();
        Task CreateProduct(Product NewProduct);
        Task UpdateProduct(Product UpdateProduct);
        Task<IEnumerable<Product>> SearcProduct(string? metal, string? types);
        Task DeleteProduct(int id);
        Task<Product> GetProduct(int id);
    }
}
