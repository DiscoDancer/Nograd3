using Nograd.ProductServices.KafkaMessages;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;

public interface IMessageHandler
{
    Task HandleAsync(ProductBaseMessage message);
}