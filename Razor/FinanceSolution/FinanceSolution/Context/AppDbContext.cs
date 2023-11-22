using FinanceSolution.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace FinanceSolution.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Release> Releases { get; set; } = default!;
    public DbSet<Account> Accounts { get; set; } = default!;
    
}
