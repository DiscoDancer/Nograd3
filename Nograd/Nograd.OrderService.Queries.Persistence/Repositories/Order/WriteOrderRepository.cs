using Microsoft.EntityFrameworkCore;
using Nograd.OrderService.Queries.Persistence.Context;
using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Repositories.Order;

public sealed class WriteOrderRepository : IWriteOrderRepository
{
    private readonly IDbContextFactory<DatabaseContext> _contextFactory;

    public WriteOrderRepository(IDbContextFactory<DatabaseContext> contextFactory)
    {
        _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    public async Task UpdateAsync(OrderEntity order)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        await using var dbContextTransaction = await context.Database.BeginTransactionAsync();
        await RemoveAsync(order.OrderId, context);
        await CreateAsync(order, context);
        await dbContextTransaction.CommitAsync();
    }

    public async Task RemoveAsync(Guid orderId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await RemoveAsync(orderId, context);
    }

    public async Task CreateAsync(OrderEntity order)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await CreateAsync(order, context);
    }

    private async Task CreateAsync(OrderEntity order, DatabaseContext existingContext)
    {
        existingContext.Orders.Add(order);
        _ = await existingContext.SaveChangesAsync();
    }

    private async Task RemoveAsync(Guid orderId, DatabaseContext existingContext)
    {
        var foundOrder = await GetByIdAsync(orderId, existingContext);
        if (foundOrder == null) throw new Exception("order not found");

        existingContext.Orders.Remove(foundOrder);
        _ = await existingContext.SaveChangesAsync();
    }

    private async Task<OrderEntity?> GetByIdAsync(Guid orderId, DatabaseContext existingContext)
    {
        return await existingContext
            .Orders
            .Include(x => x.ProductQuantities)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.OrderId == orderId);
    }
}