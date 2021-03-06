

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace NubexGold.Client.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext appDbContext;
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
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
            

            return result;
        }


        public async Task<Product> GetProductByName(string name)
        {
            return await appDbContext.Products
                .FirstOrDefaultAsync(e => e.ProductName.Contains(name));
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            //ProductDataResult result = new ProductDataResult()
            //{
            //    //Products = await appDbContext.Products.Skip(skip).Take(take),
            //    //Count = appDbContext.Products.Count()
            //    Products = appDbContext.Products.Skip(skip).Take(take),
            //    Count = await appDbContext.Products.CountAsync()
            //};
            return await appDbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProduct(Metal? metal)
        {
            //var 
            IQueryable<Product> query = appDbContext.Products;

            if (metal is not null)
            {
                query = query.Where(e => e.Metal == metal);
            }

            return await query.ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await appDbContext.Products
                .Include(c => c.Condition)
                .FirstOrDefaultAsync(e =>e.ProductId == product.ProductId);

            if(result != null)
            {
                result.ProductSKU = product.ProductSKU;
                result.ProductName = product.ProductName;
                result.Description = product.Description;
                result.Detail = product.Detail;
                result.Type = product.Type;
                result.Metal = product.Metal;
                result.MetalWeight = product.MetalWeight;
                result.MetalBrand = product.MetalBrand;
                result.Weight = product.Weight;
                //result.Condition = product.Condition;
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
                result.remark_1 = product.remark_1;
                result.remark_2 = product.remark_2;
                result.remark_3 = product.remark_3;
                result.ModifiedBy = product.ModifiedBy;
                result.ModifiedOn = product.ModifiedOn;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ProductDataResult> GetProducts(int page)
        {
            //ProductDataResult result = new ProductDataResult()
            //{
            //    Products = appDbContext.Products.Skip(skip).Take(take),
            //    Count = await appDbContext.Products.CountAsync()
            //};
            //return result;
            if (appDbContext.Products == null)
            {
                return null;
            }

            var pageResults = 8f;
            var pageCount = Math.Ceiling(appDbContext.Products.Count() / pageResults);

            var Products = await appDbContext.Products
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();
            var response = new ProductDataResult
            {
                Products = Products,
                CurrentPage = page,
                Pages = (int)pageCount,
                Count = (int)pageCount,
                
            };

            return response;
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
