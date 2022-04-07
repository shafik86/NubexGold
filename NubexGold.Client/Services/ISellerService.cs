namespace NubexGold.Client.Services
{
    public interface ISellerService
    {
        IEnumerable<Seller> Sellers { get; set; }
        Task<IEnumerable<Seller>> GetSellers();
        Task CreateSeller(Seller seller);
        Task UpdateSeller(Seller seller);
        Task<IEnumerable<Seller>> SearchSeller(string? searchString);
        Task DeleteSeller(Seller seller);
        Task<Seller> GetSeller(int id);

    }
}
