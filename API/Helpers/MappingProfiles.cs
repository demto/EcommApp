using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(p => p.ProductType, opt => opt.MapFrom(pt => pt.ProductType.Name))
                .ForMember(p => p.ProductBrand, opt => opt.MapFrom(pb => pb.ProductBrand.Name))
                .ForMember(p => p.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());

            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}