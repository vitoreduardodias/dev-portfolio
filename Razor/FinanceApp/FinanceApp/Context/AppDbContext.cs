using FinanceApp.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Release> Releases { get; set; } = default!;
    public DbSet<Account> Accounts { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Release>().ToTable(tb => tb.HasTrigger("CalculateTotalAmount"));

        base.OnModelCreating(modelBuilder);
    }
}