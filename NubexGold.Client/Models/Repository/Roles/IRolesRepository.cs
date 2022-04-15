namespace NubexGold.Client.Models.Repository.Roles
{
    public interface IRolesRepository
    {
        Task<IEnumerable<RoleResponse>> GetRoles();
    }
}
