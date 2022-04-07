namespace NubexGold.Client.Services
{
    public class SellerService : ISellerService
    {
        private readonly HttpClient httpClient;

        public IEnumerable<Seller> Sellers { get; set; } = new List<Seller>();

        public SellerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task CreateSeller(Seller seller)
        {
            await httpClient.PostAsJsonAsync("api/sellers", seller);
            //return Ok(result);
        }

        public async Task DeleteSeller(Seller seller)
        {
            var result = await httpClient.DeleteAsync($"api/sellers/{seller.SellerId}");    
        }

        public async Task<Seller> GetSeller(int id)
        {
            Seller seller = null;
            var result = await httpClient.GetFromJsonAsync<Seller>($"api/sellers/{id}");
            if (result != null)
                seller = result;
            return seller;
        }

        public async Task<IEnumerable<Seller>> GetSellers()
        {
            Sellers = new List<Seller>();
            Sellers = await httpClient.GetFromJsonAsync<IEnumerable<Seller>>("api/sellers");
            if (Sellers != null)
            {
                return Sellers;
            }
            else
                return null;
        }

        public async Task<IEnumerable<Seller>> SearchSeller(string? searchString)
        {
            Sellers = await httpClient.GetFromJsonAsync<IEnumerable<Seller>>($"api/sellers/search?string={searchString}");
            return Sellers;
        }

        //public async IEnumerable<Seller> Sellers()
        //{
        //    sellers = GetSellers();

        //    //sellers = await httpClient.GetFromJsonAsync<IEnumerable,Seller>>("api/")
        //}

        public async Task UpdateSeller(Seller seller)
        {
            await httpClient.PutAsJsonAsync($"api/sellers/{seller.SellerId}", seller);
        }
    }
}
