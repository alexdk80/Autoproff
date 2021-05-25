using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace AspNetCore
{
    public class AppDbContextMySql : DbContext
    {
        public AppDbContextMySql(DbContextOptions<AppDbContextMySql> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}