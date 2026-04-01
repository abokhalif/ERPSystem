using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCore.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }  // Primary Key

        public bool IsDeleted { get; set; } = false;  // Soft delete flag
    }
}
