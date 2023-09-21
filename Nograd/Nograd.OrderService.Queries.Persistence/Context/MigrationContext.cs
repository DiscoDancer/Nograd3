using Microsoft.EntityFrameworkCore;

namespace Nograd.OrderService.Queries.Persistence.Context;

public sealed class MigrationContext : DatabaseContext
{
    public MigrationContext() : base(new DbContextOptionsBuilder()
        .UseSqlServer(
            "Server=localhost,4201;Database=Nograd3.Orders;User Id=sa;Password=$tr0ngS@P@ssw0rd02;TrustServerCertificate=true;")
        .Options)
    {
    }
}