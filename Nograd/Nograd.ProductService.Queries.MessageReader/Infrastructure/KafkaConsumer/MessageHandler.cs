using Nograd.ProductService.Queries.MessageConsumer.Infrastructure.ProductRepository;
using Nograd.ProductServices.KafkaMessages;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;

public sealed class MessageHandler : IMessageHandler
{
    private readonly IProductRepository _productRepository;

    public MessageHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public Task HandleAsync(BaseMessage message)
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

        try
        {
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


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

        var product = await _productRepository.GetByIdAsync(message.ProductId.Value);
        if (product == null) throw new Exception("Can't find the product to update.");

        product.Category = message.Category;
        product.Description = message.Description;
        product.Name = message.Name;
        product.Price = message.Price.Value;

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