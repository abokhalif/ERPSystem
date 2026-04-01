using System.ComponentModel.DataAnnotations.Schema;
using UltimateCore.Entities;

namespace UltimateAPI.Dtos
{
    public class ProductToDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int ProductBrandId { get; set; }
        public string ProductBrand { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductCategory { get; set; }
    }
}
