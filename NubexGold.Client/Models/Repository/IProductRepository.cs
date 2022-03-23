namespace NubexGold.Client.Models.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> SearchProduct(Metal? metal, Types? type);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProduct(int productId);
        Task<Product> GetProductByName(string name);
        //Task<IEnumerable<Product>> GetProductByMetal(string metal);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int productId);
    }
}
