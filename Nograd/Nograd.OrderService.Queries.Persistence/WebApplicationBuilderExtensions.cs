using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nograd.OrderService.Queries.Persistence.Context;
using Nograd.OrderService.Queries.Persistence.Repositories.Order;
using Nograd.OrderService.Queries.Persistence.Repositories.Product;

namespace Nograd.OrderService.Queries.Persistence;

public static class WebApplicationBuilderExtensions
{
    public static void UseReadRepositories(this WebApplicationBuilder builder)
    {
        builder.UseDatabase();

        builder.Services.AddScoped<IReadOrderRepository, ReadOrderRepository>();
        builder.Services.AddScoped<IReadProductRepository, ReadProductRepository>();
    }

    public static void UseWriteRepositories(this WebApplicationBuilder builder)
    {
        builder.UseDatabase();

        builder.Services.AddScoped<IWriteOrderRepository, WriteOrderRepository>();
        builder.Services.AddScoped<IWriteProductRepository, WriteProductRepository>();
    }

    private static void UseDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContextFactory<DatabaseContext>(o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

        var factory = builder.Services.BuildServiceProvider().GetRequiredService<IDbContextFactory<DatabaseContext>>();
        var context = factory.CreateDbContext();
        context.Database.EnsureCreated();
    }
}