using Nograd.OrderService.Queries.Persistence.Context;
using Nograd.OrderService.Queries.Persistence.Entities;

namespace Nograd.OrderService.Queries.Persistence.Repositories;

public sealed class WriteOrderRepository : IWriteOrderRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly IReadOrderRepository _readOrderRepository;

    public WriteOrderRepository(DatabaseContext databaseContext, IReadOrderRepository readOrderRepository)
    {
        _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        _readOrderRepository = readOrderRepository ?? throw new ArgumentNullException(nameof(readOrderRepository));
    }

    public async Task CreateAsync(OrderEntity order)
    {
        _databaseContext.Orders.Add(order);

        _ = await _databaseContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderEntity order)
    {
        var foundOrder = await _readOrderRepository.GetByIdAsync(order.OrderId);
        if (foundOrder == null) throw new Exception("order not found");

        await RemoveAsync(order.OrderId);
        await CreateAsync(order);
    }

    public async Task RemoveAsync(Guid orderId)
    {
        var foundOrder = await _readOrderRepository.GetByIdAsync(orderId);
        if (foundOrder == null) throw new Exception("order not found");

        _databaseContext.Orders.Remove(foundOrder);
        _ = await _databaseContext.SaveChangesAsync();
    }
}