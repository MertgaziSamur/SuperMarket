using AutoMapper;
using SupermarketApp.Entities.Dtos.MarketDtos;
using SupermarketApp.Entities.Dtos.ProductDtos;
using SupermarketApp.Entities.Dtos.RayonDtos;
using SupermarketApp.Entities.Entities;

namespace SupermarketApp.API.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductDtoForCreate>().ReverseMap();
            CreateMap<Product, ProductDtoForUpdate>().ReverseMap();

            CreateMap<Rayon, RayonDto>().ReverseMap();
            CreateMap<Rayon, RayonDtoForCreate>().ReverseMap();
            CreateMap<Rayon, RayonDtoForUpdate>().ReverseMap();

            CreateMap<Market, MarketDto>().ReverseMap();
            CreateMap<Market, MarketDtoForUpdate>().ReverseMap();
            CreateMap<Market, MarketDtoForCreate>().ReverseMap();
        }
    }
}
