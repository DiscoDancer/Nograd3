using Microsoft.EntityFrameworkCore;
using Nograd.OrderService.Queries.Persistence.Context;
using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Repositories.Order;

public sealed class ReadOrderRepository : IReadOrderRepository
{
    private readonly IDbContextFactory<DatabaseContext> _contextFactory;

    public ReadOrderRepository(IDbContextFactory<DatabaseContext> contextFactory)
    {
        _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    public async Task<OrderEntity?> GetByIdAsync(Guid orderId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context
            .Orders
            .Include(x => x.ProductQuantities)
            .ThenInclude(x => x.Product)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.OrderId == orderId);
    }

    public async Task<List<OrderEntity>> ListAllAsync()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context
            .Orders
            .Include(x => x.ProductQuantities)
            .ThenInclude(x => x.Product)
            .AsNoTracking()
            .ToListAsync();
    }
}