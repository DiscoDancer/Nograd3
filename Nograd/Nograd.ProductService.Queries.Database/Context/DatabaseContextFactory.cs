using Microsoft.EntityFrameworkCore;

namespace Nograd.ProductService.Queries.Persistence.Context;

public sealed class DatabaseContextFactory
{
    private readonly Action<DbContextOptionsBuilder> _configureDbContext;

    public DatabaseContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
    {
        _configureDbContext = configureDbContext;
    }

    public DatabaseContext CreateDbContext()
    {
        DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new();
        _configureDbContext(optionsBuilder);

        return new DatabaseContext(optionsBuilder.Options);
    }
}