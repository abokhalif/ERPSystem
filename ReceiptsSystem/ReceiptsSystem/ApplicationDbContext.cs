using Microsoft.EntityFrameworkCore;
using ReceiptsSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReceiptsSystem
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ReceiptItem> ReceiptItems { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceiptItem>()
                .HasKey(ri => new { ri.ReceiptID, ri.ItemID });

            modelBuilder.Entity<Item>()
                    .Property(i => i.ItemID).ValueGeneratedNever()
                    .IsRequired();

            // .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)Configure ItemID as non-auto-generated
        }

    }
}
