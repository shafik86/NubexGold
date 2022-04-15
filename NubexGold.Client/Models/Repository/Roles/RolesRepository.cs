using Microsoft.EntityFrameworkCore;

namespace NubexGold.Client.Models.Repository.Roles
{
    public class RolesRepository : IRolesRepository
    {
        public ApplicationDbContext appDbContext { get; set; }
        public RolesRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<RoleResponse>> GetRoles()
        {
            var result = await appDbContext.RoleResponse.ToListAsync();
            return result;
        }
    }
}
