using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NubexGold.Client.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext appDbContext;
        public User UserId { get; set; }
        public IEnumerable<User> Users { get; set; }

        public UserController(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await appDbContext.Users.ToListAsync();
        }
        [HttpPost]
        public async Task<User> AddUsers(User users)
        {
            var result = await appDbContext.Users

               .AddAsync(users);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
