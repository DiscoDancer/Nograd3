using Microsoft.EntityFrameworkCore;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.ProductRepository
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
