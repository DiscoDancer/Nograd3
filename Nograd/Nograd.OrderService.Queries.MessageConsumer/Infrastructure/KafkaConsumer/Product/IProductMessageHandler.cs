using Nograd.ProductServices.KafkaMessages;

namespace Nograd.OrderService.Queries.MessageConsumer.Infrastructure.KafkaConsumer.Product;

public interface IProductMessageHandler
{
    Task HandleAsync(ProductBaseMessage message);
}