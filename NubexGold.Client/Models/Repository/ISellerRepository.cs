namespace NubexGold.Client.Models.Repository
{
    public interface ISellerRepository
    {
        Task<IEnumerable<Seller>> GetAllSellers();
        Task<IEnumerable<Seller>> SearchSeller(string searchString);

        Task<Seller> GetSellerById(int id);
        Task<Seller> GetSellerByName(string name);
        Task<Seller> AddSeller(Seller newSeller);
        Task<Seller> UpdateSeller(Seller upSeller);
        Task<Seller> DeleteSeller(int id);

    }
}
