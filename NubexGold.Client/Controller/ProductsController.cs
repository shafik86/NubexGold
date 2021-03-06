#nullable disable
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NubexGold.Client.Data;
using NubexGold.Shared;


namespace NubexGold.Client.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IProductRepository productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        // GET: api/Products/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var result = await productRepository.GetProduct(id);
            if (result == null)
            {
                return NotFound($"Product id : {id} is not found");
            }
            return Ok(result);
        }
        //Search Product by Name, Metal
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Product>>> Search(Metal? metal)
        {
            try
            {
                var result = await productRepository.SearchProduct(metal);
                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound($"tiada Product  {metal} dalam Db");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error Searching product record");
            }
        }

         //GET: api/Products
         //int skip = 0, int take = 5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
               return Ok( await productRepository.GetAllProducts());
              
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Error Retrieving data from server");
            }
            
        }

        // GET: api/Products with pagination
        // int skip = 0, int take = 5
        [HttpGet("page/{page}")]
        public async Task<ActionResult<ProductDataResult>> GetProducts(int page)
        {
            var result = await productRepository.GetProducts(page);
            return Ok(result);
        }



        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Edit")]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            try
            {
                if (product.ProductId == 0)
                    return BadRequest("Product ID mismatch");

                var productToUpdate = await productRepository.GetProduct(product.ProductId);

                if (productToUpdate == null)
                    return NotFound($"Product with Id = {product.ProductId} not found");

                return await productRepository.UpdateProduct(product);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data" + e.ToString());
            }
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            try
            {
                if (product == null)
                    return BadRequest();

                var createdProduct = await productRepository.AddProduct(product);

                return CreatedAtAction(nameof(GetProduct),
                    new { id = createdProduct.ProductId }, createdProduct);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new product record");
                
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var productToDelete = await productRepository.GetProduct(id);
            try
            {
                //var employeeToDelete = await employeeRepository.GetEmployee(id);
                if (productToDelete == null)
                {
                    return NotFound($"Product with Id = {id} not found");
                }

                return await productRepository.DeleteProduct(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.ProductId == id);
        //}
    }
}
