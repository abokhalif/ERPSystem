using AutoMapper;
using UltimateAPI.Dtos;
using UltimateCore.Entities;

namespace UltimateAPI.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductToDto, string>
    {
        private readonly IConfiguration configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, ProductToDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{configuration["ApiBaseUrl"]}/{source.PictureUrl}";
            return string.Empty;
        }
    }
}
