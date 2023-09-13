using Microsoft.EntityFrameworkCore;
using Nograd.OrderService.Queries.Persistence.Context;
using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Repositories;

public sealed class WriteOrderRepository : IWriteOrderRepository
{
    private readonly IDbContextFactory<DatabaseContext> _contextFactory;

    public WriteOrderRepository(IDbContextFactory<DatabaseContext> contextFactory)
    {
        _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    public async Task CreateAsync(OrderEntity order)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        context.Orders.Add(order);
        _ = await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderEntity order)
    {
        await RemoveAsync(order.OrderId);
        await CreateAsync(order);
    }

    public async Task RemoveAsync(Guid orderId)
    {
        var foundOrder = await GetByIdAsync(orderId);
        if (foundOrder == null) throw new Exception("order not found");

        await using var context = await _contextFactory.CreateDbContextAsync();
        context.Orders.Remove(foundOrder);
        _ = await context.SaveChangesAsync();
    }

    private async Task<OrderEntity?> GetByIdAsync(Guid orderId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context
            .Orders
            .Include(x => x.ProductQuantities)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.OrderId == orderId);
    }
}