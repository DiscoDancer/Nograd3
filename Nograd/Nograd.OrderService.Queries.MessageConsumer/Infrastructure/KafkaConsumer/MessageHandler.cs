using Nograd.OrderService.KafkaMessages;
using Nograd.OrderService.Queries.Persistence.Entities;
using Nograd.OrderService.Queries.Persistence.Repositories;

namespace Nograd.OrderService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;

public sealed class MessageHandler : IMessageHandler
{
    private readonly IWriteOrderRepository _orderRepository;

    public MessageHandler(IWriteOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public Task HandleAsync(BaseMessage message)
    {
        return message switch
        {
            OrderCreatedMessage m => HandleAsync(m),
            OrderUpdatedMessage m => HandleAsync(m),
            OrderRemovedMessage m => HandleAsync(m),
            _ => throw new NotImplementedException("Unrecognized message received.")
        };
    }

    private async Task HandleAsync(OrderCreatedMessage message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        if (string.IsNullOrWhiteSpace(message.CustomerAddress)) throw new ArgumentNullException(nameof(message.CustomerAddress));
        if (string.IsNullOrWhiteSpace(message.CustomerName)) throw new ArgumentNullException(nameof(message.CustomerName));
        if (message.IsGift == null) throw new ArgumentNullException(nameof(message.IsGift));
        if (message.IsShipped == null) throw new ArgumentNullException(nameof(message.IsShipped));
        if (message.OrderId == null || message.OrderId == Guid.Empty) throw new ArgumentNullException(nameof(message.OrderId));
        if (message.ProductQuantities == null) throw new ArgumentNullException(nameof(message.ProductQuantities));
        if (message.ProductQuantities.Any(x => x?.ProductId == null || x.ProductId == Guid.Empty || x.Quantity == null || x.Quantity <= 0)) throw new ArgumentNullException(nameof(message.ProductQuantities));


        try
        {
            var productQuantities = message
                .ProductQuantities
                .Select(x => new ProductQuantityEntity { ProductId = x.ProductId!.Value, Quantity = x.Quantity!.Value })
                .ToList();

            var order = new OrderEntity
            {
                CustomerAddress = message.CustomerAddress,
                CustomerName = message.CustomerName,
                IsGift = message.IsGift.Value,
                IsShipped = message.IsShipped.Value,
                OrderId = message.OrderId.Value,
                ProductQuantities = productQuantities
            };


            await _orderRepository.CreateAsync(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


    }

    private async Task HandleAsync(OrderUpdatedMessage message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        if (string.IsNullOrWhiteSpace(message.CustomerAddress)) throw new ArgumentNullException(nameof(message.CustomerAddress));
        if (string.IsNullOrWhiteSpace(message.CustomerName)) throw new ArgumentNullException(nameof(message.CustomerName));
        if (message.IsGift == null) throw new ArgumentNullException(nameof(message.IsGift));
        if (message.IsShipped == null) throw new ArgumentNullException(nameof(message.IsShipped));
        if (message.OrderId == null || message.OrderId == Guid.Empty) throw new ArgumentNullException(nameof(message.OrderId));
        if (message.ProductQuantities == null) throw new ArgumentNullException(nameof(message.ProductQuantities));
        if (message.ProductQuantities.Any(x => x?.ProductId == null || x.ProductId == Guid.Empty || x.Quantity == null || x.Quantity <= 0)) throw new ArgumentNullException(nameof(message.ProductQuantities));

        var productQuantities = message
            .ProductQuantities
            .Select(x => new ProductQuantityEntity { ProductId = x.ProductId!.Value, Quantity = x.Quantity!.Value })
            .ToList();

        try
        {
            var order = new OrderEntity
            {
                CustomerAddress = message.CustomerAddress,
                CustomerName = message.CustomerName,
                IsGift = message.IsGift.Value,
                IsShipped = message.IsShipped.Value,
                OrderId = message.OrderId.Value,
                ProductQuantities = productQuantities
            };


            await _orderRepository.UpdateAsync(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    private async Task HandleAsync(OrderRemovedMessage message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        if (message.OrderId == null || message.OrderId == Guid.Empty) throw new ArgumentNullException(nameof(message.OrderId));

        try
        {
            await _orderRepository.RemoveAsync(message.OrderId.Value);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}