using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCore.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }  // Primary Key

        //[Required]
        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Auto-set on creation

        //public DateTime? UpdatedAt { get; set; }  // Nullable, set only when updated

        public bool IsDeleted { get; set; } = false;  // Soft delete flag

        //[Timestamp]
        //public byte[] RowVersion { get; set; }  // Concurrency token

        //[StringLength(50)]
        //public string CreatedBy { get; set; }  // Tracks who created the record

        //[StringLength(50)]
        //public string UpdatedBy { get; set; }  // Tracks who last updated the record
    }
}
