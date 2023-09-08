using Nograd.OrderService.Commands.Domain.Events;
using Nograd.OrderService.KafkaMessages;

namespace Nograd.OrderService.Commands.Domain
{
    public interface IEventToMessageMapper
    {
        BaseMessage Map(BaseEvent @event);
    }
}
