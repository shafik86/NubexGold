namespace NubexGold.Client.Services
{
    public interface IPriceService
    {
        golds curPrice { get; set; }
        Task<golds> getAllPrice();
    }
}
