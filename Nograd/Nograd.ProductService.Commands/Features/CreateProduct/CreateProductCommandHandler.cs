using MediatR;
using Nograd.ProductService.Commands.Domain;
using Nograd.ProductService.Commands.Features.Base;

namespace Nograd.ProductService.Commands.Features.CreateProduct;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductEventHandlingStrategy _eventHandlingStrategy;

    public CreateProductCommandHandler(IProductEventHandlingStrategy eventHandlingStrategy)
    {
        _eventHandlingStrategy = eventHandlingStrategy ?? throw new ArgumentNullException(nameof(eventHandlingStrategy));
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productId = Guid.NewGuid();
        var product = Product.GetNotCreatedProduct();
        var productCreatedEvent = ProductEventProducer.Create(
            product,
            request.Name,
            request.Description,
            request.Category,
            request.Price,
            productId);

        await _eventHandlingStrategy.HandleAsync(productCreatedEvent, productId);
    }
}