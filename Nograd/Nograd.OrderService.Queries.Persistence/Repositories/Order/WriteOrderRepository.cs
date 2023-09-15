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

        var foundOrder = await GetByIdAsync(order.OrderId, context);
        if (foundOrder == null) throw new Exception("order not found");
        context.Orders.Remove(foundOrder);
        context.Orders.Add(order);

        _ = await context.SaveChangesAsync();
        await dbContextTransaction.CommitAsync();
    }

    public async Task RemoveAsync(Guid orderId)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var foundOrder = await GetByIdAsync(orderId, context);
        if (foundOrder == null) throw new Exception("order not found");

        context.Orders.Remove(foundOrder);
        _ = await context.SaveChangesAsync();
    }

    public async Task CreateAsync(OrderEntity order)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        context.Orders.Add(order);
        _ = await context.SaveChangesAsync();
    }

    private static async Task<OrderEntity?> GetByIdAsync(Guid orderId, DatabaseContext existingContext)
    {
        return await existingContext
            .Orders
            .Include(x => x.ProductQuantities)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.OrderId == orderId);
    }
}