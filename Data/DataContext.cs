using dotnet_bugtrackerapi.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_bugtrackerapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Fix> Fixes { get; set; }
        public DbSet<Breakage> Breakages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fix>().HasData(
                new Fix { Id = 1, HowFixed = "Added wait", BreakageId = 1 },
                new Fix { Id = 2, HowFixed = "Updated CSS Selector", BreakageId = 2 }
            );

            modelBuilder.Entity<Breakage>().HasData(
                new Breakage { Id = 1, BreakageReason = "Timeout Exception" },
                new Breakage { Id = 2, BreakageReason = "Stale Element Exception" }
            );
        }
    }
}