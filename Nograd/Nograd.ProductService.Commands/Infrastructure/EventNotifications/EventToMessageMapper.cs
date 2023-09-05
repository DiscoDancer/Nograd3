using Nograd.ProductService.Commands.Domain;
using Nograd.ProductService.Commands.Domain.Events;
using Nograd.ProductServices.KafkaMessages;

namespace Nograd.ProductService.Commands.Infrastructure.EventNotifications
{
    public sealed class EventToMessageMapper: IEventToMessageMapper
    {
        public BaseMessage Map(BaseEvent @event)
        {
            return @event switch
            {
                ProductCreatedEvent ev => new ProductCreatedMessage(
                    name: ev.Name,
                    description: ev.Description,
                    category: ev.Category,
                    productId: ev.ProductId,
                    price: ev.Price),
                ProductUpdatedEvent ev => new ProductUpdatedMessage(
                    name: ev.Name,
                    description: ev.Description,
                    category: ev.Category,
                    productId: ev.ProductId,
                    price: ev.Price),
                ProductRemovedEvent ev => new ProductRemovedMessage(productId: ev.ProductId),
                _ => throw new NotImplementedException()
            };
        }
    }
}
