namespace NubexGold.Client.Models.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> SearchProduct(Metal? metal);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<ProductDataResult> GetProducts(int page);
        Task<Product?> GetProduct(int productId);
        Task<Product> GetProductByName(string name);
        //Task<IEnumerable<Product>> GetProductByMetal(string metal);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int productId);
    }
}
