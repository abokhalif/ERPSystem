using System.ComponentModel.DataAnnotations;

namespace ReceiptsSystem.Models
{
    public class ReceiptItem
    {
        public int ReceiptID { get; set; }

        public int ItemID { get; set; }

        [Required]
        public int Quantity { get; set; }

        public virtual Receipt Receipt { get; set; }
        public virtual Item Item { get; set; }
    }
}
