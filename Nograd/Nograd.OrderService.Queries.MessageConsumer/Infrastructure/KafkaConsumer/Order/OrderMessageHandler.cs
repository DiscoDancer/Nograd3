using Nograd.OrderService.KafkaMessages;
using Nograd.OrderService.Queries.Persistence.Entities;
using Nograd.OrderService.Queries.Persistence.Repositories.Order;
using Nograd.OrderService.Queries.Persistence.Repositories.Product;

namespace Nograd.OrderService.Queries.MessageConsumer.Infrastructure.KafkaConsumer.Order;

public sealed class OrderMessageHandler : IOrderMessageHandler
{
    private readonly IWriteOrderRepository _orderRepository;
    private readonly IReadProductRepository _productRepository;

    public OrderMessageHandler(IWriteOrderRepository orderRepository, IReadProductRepository productRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public Task HandleAsync(OrderBaseMessage message)
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

            var productQuantities = new List<ProductQuantityEntity>();
            foreach (var pq in message.ProductQuantities)
            {
                var productId = pq.ProductId!.Value;
                var quantity = pq.Quantity!.Value;

                var product = await _productRepository.GetByIdAsync(productId);
                if (product == null) throw new Exception($"Can't find product by id {productId}");

                productQuantities.Add(new ProductQuantityEntity()
                {
                    ProductId = productId,
                    Quantity = quantity,
                });
            }

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

        var productQuantities = new List<ProductQuantityEntity>();
        foreach (var pq in message.ProductQuantities)
        {
            var productId = pq.ProductId!.Value;
            var quantity = pq.Quantity!.Value;

            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) throw new Exception($"Can't find product by id {productId}");

            productQuantities.Add(new ProductQuantityEntity()
            {
                Product = product,
                Quantity = quantity,
            });
        }

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