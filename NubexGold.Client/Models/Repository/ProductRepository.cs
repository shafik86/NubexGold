

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace NubexGold.Client.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext appDbContext;
        public IEnumerable<Product> Product { get; set; } = new List<Product>();
        [Inject]
        public Mapper mapper { get; set; }
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
            var result = await appDbContext.Products
                 .Include(e => e.Condition)
                 //.Include(e => e.Metal)
                 .FirstOrDefaultAsync(e => e.ProductId == productId);
            if (result != null || result.ProductId != 0)
                return result;

            return null;
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
                if (type is not null)
                {
                    query = query.Where(e => e.Type == type);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await appDbContext.Products.FirstOrDefaultAsync(e => e.ProductId == product.ProductId);

            if(result != null)
            {
                result.SKU = product.SKU;
                result.Name = product.Name;
                result.Description = product.Description;
                result.Detail = product.Detail;
                result.Type = product.Type;
                result.Metal = product.Metal;
                result.MetalWeight = product.MetalWeight;
                result.MetalBrand = product.MetalBrand;
                result.Weight = product.Weight;
                result.Condition = product.Condition;
                result.ConditionId = product.ConditionId;
                result.Purify = product.Purify;
                result.Manufacture = product.Manufacture;
                result.Certificate = product.Certificate;
                result.IsTax = product.IsTax;
                result.Featured = product.Featured;
                result.Price = product.Price;
                result.Color = product.Color;  
                result.ProductTag = product.ProductTag;
                result.Image1 = product.Image1;
                result.Image2 = product.Image2;
                result.Image3 = product.Image3;
                result.ModifiedBy = product.ModifiedBy;
                result.ModifiedOn = product.ModifiedOn;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
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
