
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace NubexGold.Client.Models.Repository
{
    public class SellerRepository : ISellerRepository
    {
        public IEnumerable<Seller> Sellers { get; set; }= new List<Seller>();
        private readonly ApplicationDbContext appDbContext;

        public SellerRepository(ApplicationDbContext applicationDbContext)
        {
            this.appDbContext = applicationDbContext;
        }

        public async Task<Seller> AddSeller(Seller newSeller)
        {
            var result = await appDbContext.Sellers
                 .AddAsync(newSeller);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Seller> DeleteSeller(int id)
        {
            var result = await appDbContext.Sellers
               .FirstOrDefaultAsync(e => e.SellerId == id);
            if (result != null)
            {
                appDbContext.Sellers.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Seller>> GetAllSellers()
        {
            return await appDbContext.Sellers.ToListAsync();
        }

        public async Task<Seller> GetSellerById(int id)
        {
            var result = await appDbContext.Sellers
               .FirstOrDefaultAsync(e => e.SellerId == id);
            if (result != null)
            {
                appDbContext.Sellers.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Seller> GetSellerByName(string name)
        {
            return await appDbContext.Sellers
                .FirstOrDefaultAsync(e => e.SellerName.Contains(name));
        }

        public async Task<IEnumerable<Seller>> SearchSeller(string searchString)
        {
            IQueryable<Seller> query = appDbContext.Sellers;

            if (searchString is not null)
            {
                query = query.Where(e => e.SellerName.Contains(searchString) || e.SellerEmail.Contains(searchString) || e.City.Contains(searchString)
                || e.SellerAddress.Contains(searchString));
                
            }

            return await query.ToListAsync();
        }

        public async Task<Seller> UpdateSeller(Seller upSeller)
        {
            var message = "Seller not Found!!";
           var result =  await appDbContext.Sellers.FirstOrDefaultAsync(s => s.SellerId == upSeller.SellerId);
            if (result != null)
            {
                //save code
                result.SellerName = upSeller.SellerName;
                result.SellerContact = upSeller.SellerContact;
                result.SellerAddress = upSeller.SellerAddress;
                result.SellerEmail = upSeller.SellerEmail;
                result.City = upSeller.City;
                result.PostalCode = upSeller.PostalCode;
                result.Country = upSeller.Country;
                result.SellerCompany = upSeller.SellerCompany;
                result.CompanyLicense = upSeller.CompanyLicense;
                result.SellerWallet = upSeller.SellerWallet;
                result.ComsType = upSeller.ComsType;
                result.ComsPercent = upSeller.ComsPercent;
                result.ComsFix = upSeller.ComsFix;
                result.ComsFixPer = upSeller.ComsFixPer;
                result.AccNumber = upSeller.AccNumber;
                result.BankName = upSeller.BankName;
                result.BankHolder = upSeller.BankHolder;
                result.ModifiedBy = upSeller.ModifiedBy;
                result.ModifiedOn = DateTime.Now;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            else
            {
                return result;

            }
            return null;
        }
    }
}
