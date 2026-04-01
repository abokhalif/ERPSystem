using Microsoft.EntityFrameworkCore;
using ReceiptsSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace ReceiptsSystem.Configurations;

public class ItemConfiguration : EntityTypeConfiguration<Item>
{
    public ItemConfiguration()
    {

        // ItemID configuration
        Property(i => i.ItemID)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None) // Configure ItemID as non-auto-generated
            .IsRequired(); // Mark ItemID as required
    }

}
