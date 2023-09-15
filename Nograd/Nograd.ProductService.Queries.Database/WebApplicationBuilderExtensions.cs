using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nograd.ProductService.Queries.Persistence.Context;
using Nograd.ProductService.Queries.Persistence.Repositories;

namespace Nograd.ProductService.Queries.Persistence;

public static class WebApplicationBuilderExtensions
{
    public static void UseReadProductRepository(this WebApplicationBuilder builder)
    {
        builder.UseDatabase();

        builder.Services.AddScoped<IReadProductRepository, ReadProductRepository>();
    }

    public static void UseWriteProductRepository(this WebApplicationBuilder builder)
    {
        builder.UseDatabase();

        builder.Services.AddScoped<IWriteProductRepository, WriteProductRepository>();
    }

    private static void UseDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContextFactory<DatabaseContext>(o =>
            o.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

        var factory = builder.Services.BuildServiceProvider().GetRequiredService<IDbContextFactory<DatabaseContext>>();
        var context = factory.CreateDbContext();
        context.Database.EnsureCreated();
    }
}