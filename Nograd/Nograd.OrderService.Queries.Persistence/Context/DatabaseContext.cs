using Microsoft.EntityFrameworkCore;
using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Context;

#pragma warning disable CS8618

public sealed class DatabaseContext : DbContext
{
    public DbSet<OrderEntity> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,3333;Database=Nograd3.Orders;User Id=sa;Password=$tr0ngS@P@ssw0rd02;TrustServerCertificate=true;");

    //public DbSet<ProductQuantityEntity> ProductQuantities { get; set; }
}