using Nograd.ProductService.Commands.Domain.Events;
using Nograd.ProductServices.KafkaMessages;

namespace Nograd.ProductService.Commands.Domain
{
    public interface IEventToMessageMapper
    {
        ProductBaseMessage Map(BaseEvent @event);
    }
}
