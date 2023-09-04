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
                ProductCreatedEvent ev => new ProductCreatedMessage(Name: ev.Name, Description: ev.Description,
                    Category: ev.Category, ProductId: ev.ProductId, Price: ev.Price),
                ProductUpdatedEvent ev => new ProductUpdatedMessage(Name: ev.Name, Description: ev.Description,
                    Category: ev.Category, ProductId: ev.ProductId, Price: ev.Price),
                ProductRemovedEvent ev => new ProductRemovedMessage(ProductId: ev.ProductId),
                _ => throw new NotImplementedException()
            };
        }
    }
}
