using Nograd.OrderService.KafkaMessages;

namespace Nograd.OrderService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;

public interface IMessageHandler
{
    Task HandleAsync(BaseMessage message);
}