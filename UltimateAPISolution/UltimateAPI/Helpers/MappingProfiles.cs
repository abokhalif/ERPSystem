using AutoMapper;
using UltimateAPI.Dtos;
using UltimateCore.Entities;

namespace UltimateAPI.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToDto>()
                .ForMember(d=>d.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(d=>d.ProductCategory,o=>o.MapFrom(s=>s.ProductCategory.Name))
                .ForMember(d=>d.PictureUrl,o=>o.MapFrom<ProductPictureUrlResolver>());


        }
    }
}
