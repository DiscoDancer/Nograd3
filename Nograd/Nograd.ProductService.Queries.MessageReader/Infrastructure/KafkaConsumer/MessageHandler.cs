using Nograd.ProductService.Queries.Persistence.Entities;
using Nograd.ProductService.Queries.Persistence.Repositories;
using Nograd.ProductServices.KafkaMessages;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;

public sealed class MessageHandler : IMessageHandler
{
    private readonly IWriteProductRepository _productRepository;

    public MessageHandler(IWriteProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public Task HandleAsync(ProductBaseMessage message)
    {
        return message switch
        {
            ProductCreatedMessage m => HandleAsync(m),
            ProductUpdatedMessage m => HandleAsync(m),
            ProductRemovedMessage m => HandleAsync(m),
            _ => throw new NotImplementedException("Unrecognized message received.")
        };
    }

    private async Task HandleAsync(ProductCreatedMessage message)
    {
        if (message == null) throw new ArgumentNullException();
        if (string.IsNullOrWhiteSpace(message.Name)) throw new ArgumentNullException(nameof(message.Name));
        if (string.IsNullOrWhiteSpace(message.Description))
            throw new ArgumentNullException(nameof(message.Description));
        if (string.IsNullOrWhiteSpace(message.Category)) throw new ArgumentNullException(nameof(message.Category));
        if (message.ProductId == null || message.ProductId == Guid.Empty)
            throw new ArgumentNullException(nameof(message.ProductId));
        if (message.Price == null || message.Price <= 0) throw new ArgumentNullException(nameof(message.Price));

        var product = new ProductEntity
        {
            Category = message.Category,
            Description = message.Description,
            Name = message.Name,
            Price = message.Price.Value,
            ProductId = message.ProductId.Value
        };

        await _productRepository.CreateAsync(product);
    }

    private async Task HandleAsync(ProductUpdatedMessage message)
    {
        if (message == null) throw new ArgumentNullException();
        if (string.IsNullOrWhiteSpace(message.Name)) throw new ArgumentNullException(nameof(message.Name));
        if (string.IsNullOrWhiteSpace(message.Description))
            throw new ArgumentNullException(nameof(message.Description));
        if (string.IsNullOrWhiteSpace(message.Category)) throw new ArgumentNullException(nameof(message.Category));
        if (message.ProductId == null || message.ProductId == Guid.Empty)
            throw new ArgumentNullException(nameof(message.ProductId));
        if (message.Price == null || message.Price <= 0) throw new ArgumentNullException(nameof(message.Price));


        var product = new ProductEntity
        {
            ProductId = message.ProductId.Value,
            Category = message.Category,
            Description = message.Description,
            Name = message.Name,
            Price = message.Price.Value
        };
        await _productRepository.UpdateAsync(product);
    }

    private async Task HandleAsync(ProductRemovedMessage message)
    {
        if (message == null) throw new ArgumentNullException();
        if (message.ProductId == null || message.ProductId == Guid.Empty)
            throw new ArgumentNullException(nameof(message.ProductId));

        await _productRepository.RemoveAsync(message.ProductId.Value);
    }
}