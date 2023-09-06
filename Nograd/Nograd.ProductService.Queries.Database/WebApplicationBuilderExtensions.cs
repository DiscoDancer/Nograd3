using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nograd.ProductService.Queries.Persistence;

public static class WebApplicationBuilderExtensions
{
    public static void UseReadProductRepository(this WebApplicationBuilder builder)
    {
        Action<DbContextOptionsBuilder> configureDbContext = o =>
            o.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
        builder.Services.AddDbContext<DatabaseContext>(configureDbContext);

        // Create database and tables from code
        var dataContext = builder.Services.BuildServiceProvider().GetRequiredService<DatabaseContext>();
        dataContext.Database.EnsureCreated();

        builder.Services.AddSingleton(new DatabaseContextFactory(configureDbContext));
        builder.Services.AddScoped<IReadProductRepository, ReadProductRepository>();
    }

    public static void UseWriteProductRepository(this WebApplicationBuilder builder)
    {
        Action<DbContextOptionsBuilder> configureDbContext = o =>
            o.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
        builder.Services.AddDbContext<DatabaseContext>(configureDbContext);

        // Create database and tables from code
        var dataContext = builder.Services.BuildServiceProvider().GetRequiredService<DatabaseContext>();
        dataContext.Database.EnsureCreated();

        builder.Services.AddSingleton(new DatabaseContextFactory(configureDbContext));
        builder.Services.AddScoped<IReadProductRepository, ReadProductRepository>();
        builder.Services.AddScoped<IWriteProductRepository, WriteProductRepository>();
    }
}