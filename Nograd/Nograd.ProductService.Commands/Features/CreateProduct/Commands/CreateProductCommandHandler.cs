using MediatR;
using Nograd.ProductService.Commands.Domain;

namespace Nograd.ProductService.Commands.Features.CreateProduct.Commands;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductEventHandlingStrategy _eventHandlingStrategy;

    public CreateProductCommandHandler(IProductEventHandlingStrategy eventHandlingStrategy)
    {
        _eventHandlingStrategy = eventHandlingStrategy ?? throw new ArgumentNullException(nameof(eventHandlingStrategy));
    }

    public async Task Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = Product.GetNotCreatedProduct();
        var productCreatedEvent = ProductEventProducer.Create(
            product,
            command.Name,
            command.Description,
            command.Category,
            command.Price,
            command.ProductId);

        await _eventHandlingStrategy.HandleAsync(productCreatedEvent, command.ProductId);
    }
}