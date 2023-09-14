using Nograd.OrderService.KafkaMessages;

namespace Nograd.OrderService.Queries.MessageConsumer.Infrastructure.KafkaConsumer.Order;

public interface IOrderMessageHandler
{
    Task HandleAsync(OrderBaseMessage message);
}