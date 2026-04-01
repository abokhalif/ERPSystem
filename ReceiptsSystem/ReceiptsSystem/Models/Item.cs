using System.ComponentModel.DataAnnotations;

namespace ReceiptsSystem.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }//Not generated

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal AmountSold { get; set; }

        [Required]
        public decimal Balance { get; set; }
        public virtual ICollection<ReceiptItem> ReceiptItems { get; set; } = new List<ReceiptItem>();
    }
}
