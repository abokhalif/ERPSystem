using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UltimateCore.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }

        [ForeignKey(nameof(Product.ProductBrand))]
        public int ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }

        [ForeignKey(nameof(Product.ProductCategory))]
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

    }
}
