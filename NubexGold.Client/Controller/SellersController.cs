using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NubexGold.Client.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        public SellersController(ISellerRepository sellerRepository)
        {
            SellerRepository = sellerRepository;
        }

        public ISellerRepository SellerRepository { get; }
        
        // GET: api/Sellers/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Seller>> GetSeller(int id)
        {
            var result = await SellerRepository.GetSellerById(id);
            if (result == null)
            {
                return NotFound($"Seller id : {id} is not found");
            }
            return Ok(result);
        }

        //Search Seller by String
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Seller>>> Search(string search)
        {
            try
            {
                var result = await SellerRepository.SearchSeller(search);
                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound($"tiada Seller  {search} dalam Db");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error Searching seller record");
            }
        }

        // GET: api/Sellers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetProducts()
        {
            var result = await SellerRepository.GetAllSellers();
            return Ok(result);
        }




        // PUT: api/sellers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        //[Route("Edit")]
        public async Task<ActionResult<Seller>> UpdateSeller(Seller seller)
        {
            try
            {
                if (seller.SellerId == 0)
                    return BadRequest("seller ID mismatch");

                var sellerToUpdate = await SellerRepository.GetSellerById(seller.SellerId);

                if (sellerToUpdate == null)
                    return NotFound($"seller with Id = {seller.SellerId} not found");

                var result = await SellerRepository.UpdateSeller(seller);
                if (result != null)
                {
                    return Ok(result);
                }
                return null;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data" + e.ToString());
            }
        }

        // POST: api/sellers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seller>> CreateSeller(Seller seller)
        {
            try
            {
                if (seller == null)
                    return BadRequest();

                var createdseller = await SellerRepository.AddSeller(seller);

                return CreatedAtAction(nameof(GetSeller),
                    new { id = createdseller.SellerId }, createdseller);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new product record \n" + e.ToString());

            }
        }

        // DELETE: api/Sellers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seller>> DeleteSeller(int id)
        {
            var sellerToDelete = await SellerRepository.GetSellerById(id);
            try
            {
                //var employeeToDelete = await employeeRepository.GetEmployee(id);
                if (sellerToDelete == null)
                {
                    return NotFound($"Product with Id = {id} not found");
                }

                return await SellerRepository.DeleteSeller(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data\n" + e.Message);
            }
        }

        //private bool SellerExists(int id)
        //{
        //    //return  SellerRepository.GetSellerById.Any(id);
        //    return ApplicationDbContext.ReferenceEquals(null, id);
        //}

    }
}
