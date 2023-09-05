using Microsoft.EntityFrameworkCore;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.ProductRepository
{
    public static class WebApplicationBuilderExtensions
    {
        public static void UseProductRepository(this WebApplicationBuilder builder)
        {
            Action<DbContextOptionsBuilder> configureDbContext = (o => o.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
            builder.Services.AddDbContext<DatabaseContext>(configureDbContext);

            // Create database and tables from code
            var dataContext = builder.Services.BuildServiceProvider().GetRequiredService<DatabaseContext>();
            dataContext.Database.EnsureCreated();

            builder.Services.AddSingleton(new DatabaseContextFactory(configureDbContext));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
