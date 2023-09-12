using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nograd.OrderService.Queries.Persistence.Context;
using Nograd.OrderService.Queries.Persistence.Repositories;

namespace Nograd.OrderService.Queries.Persistence;

public static class WebApplicationBuilderExtensions
{
    public static void UseReadOrderRepository(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DatabaseContext>();

        var dataContext = builder.Services.BuildServiceProvider().GetRequiredService<DatabaseContext>();
        dataContext.Database.EnsureCreated();

        builder.Services.AddScoped<IReadOrderRepository, ReadOrderRepository>();
    }

    public static void UseWriteOrderRepository(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DatabaseContext>();

        var dataContext = builder.Services.BuildServiceProvider().GetRequiredService<DatabaseContext>();
        dataContext.Database.EnsureCreated();

        builder.Services.AddScoped<IReadOrderRepository, ReadOrderRepository>();
        builder.Services.AddScoped<IWriteOrderRepository, WriteOrderRepository>();
    }
}