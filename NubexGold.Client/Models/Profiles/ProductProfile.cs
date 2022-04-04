using AutoMapper;

namespace NubexGold.Client.Models.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditModel, Product>();
            CreateMap<Product, AddEditModel>();
            
        }
    }
}
