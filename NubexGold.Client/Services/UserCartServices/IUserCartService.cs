namespace NubexGold.Client.Services.UserCartServices
{
    public interface IUserCartService
    {
        //Task<UserCart> GetCart(int Userid);
        Task<IEnumerable<UserCart>> GetAllCarts();
        Task<IEnumerable<UserCart>> GetAllCartsPaginated(int page, int pageSize);
        Task UpdateCartItem(string id, List<UserCart> item);
        Task<UserCart> AddToCart(UserCart ItemCart);
        Task DeleteCartItem(int cart);

    }
}
