

using Microsoft.EntityFrameworkCore;

namespace NubexGold.Client.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            this.appDbContext = applicationDbContext;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var result = await appDbContext.Products

                .AddAsync(product);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            //
            var result = await appDbContext.Products
                .FirstOrDefaultAsync(e => e.ProductId == productId);
            if (result != null)
            {
                appDbContext.Products.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await appDbContext.Products
                 //.Include(e => e.Condition)
                 //.Include(e => e.Metal)
                 .FirstOrDefaultAsync(e => e.ProductId == productId);
        }


        public async Task<Product> GetProductByName(string name)
        {
            return await appDbContext.Products
                .FirstOrDefaultAsync(e => e.Name.Contains(name));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await appDbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProduct(Metal? metal, Types? type)
        {
            //var 
            IQueryable<Product> query = appDbContext.Products;

            if (metal is not null)
            {
                query = query.Where(e => e.Metal == metal);
            }
            if (type is not null)
            {
                query = query.Where(e => e.Type == type);
            }

            return await query.ToListAsync();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        //async Task<IEnumerable<Product>> IProductRepository.GetProductByMetal(string metal)
        //{
        //    IQueryable<Product> query = appDbContext.Products;
        //    if (!string.IsNullOrEmpty(metal))
        //    {
        //        query = query.Where(e => e.Metal.Equals(metal));
        //    }
        //    return await query.ToListAsync();
        //}
    }
}
