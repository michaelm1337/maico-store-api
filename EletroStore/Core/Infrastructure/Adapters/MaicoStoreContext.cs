using Domain.Entities;
using Infrastructure.Adapters.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Adapters
{
    public class MaicoStoreContext : DbContext
    {
        public MaicoStoreContext(DbContextOptions<MaicoStoreContext> options) : base(options) { }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
    }
}
