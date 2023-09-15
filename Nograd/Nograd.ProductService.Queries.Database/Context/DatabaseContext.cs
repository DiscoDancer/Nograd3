using Microsoft.EntityFrameworkCore;
using Nograd.ProductService.Queries.Persistence.Entities;

#pragma warning disable CS8618

namespace Nograd.ProductService.Queries.Persistence.Context
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
