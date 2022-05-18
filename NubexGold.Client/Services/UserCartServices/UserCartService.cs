namespace NubexGold.Client.Services.UserCartServices
{
    public class UserCartService : IUserCartService
    {
        private readonly HttpClient httpClient;
        public ItemCart Items { get; set; } = new ItemCart();
       
        public UserCartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserCart> AddToCart(UserCart ItemCart)
        {
            var result = await httpClient.PostAsJsonAsync<UserCart>("api/usercart", ItemCart);
            return null;
        }

        public async Task DeleteCartItem(int cart)
        {
            var result = await httpClient.DeleteAsync($"api/usercart/{cart}");
            
        }

        public async Task<IEnumerable<UserCart>> GetAllCarts()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<UserCart>>("api/usercart");

            return result;
        }

        public Task<IEnumerable<UserCart>> GetAllCartsPaginated(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        //public Task<UserCart> GetCart(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task UpdateCartItem(string id, List<UserCart> item)
        {
            var result = await httpClient.PostAsJsonAsync<IEnumerable<UserCart>>($"api/usercart{id}", item);
            
        }
    }
}
