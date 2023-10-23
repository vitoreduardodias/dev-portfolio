using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MyStock.Models.Tables;
using System.Reflection.Metadata;

namespace MyStock.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Entry> Entries { get; set; } = default!;
        public DbSet<Output> Outputs { get; set; } = default!;
        public DbSet<Supplier> Suppliers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>()
                .ToTable(tb => tb.HasTrigger("trgAfterInsertEntry"));
        }
    }
}
