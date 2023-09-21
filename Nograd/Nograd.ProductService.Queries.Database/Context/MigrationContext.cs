using Microsoft.EntityFrameworkCore;

namespace Nograd.ProductService.Queries.Persistence.Context;

public sealed class MigrationContext : DatabaseContext
{
    public MigrationContext() : base(new DbContextOptionsBuilder().UseSqlServer("Server=localhost,4200;Database=Nograd3.Products;User Id=sa;Password=$tr0ngS@P@ssw0rd02;TrustServerCertificate=true;").Options)
    {

    }
}