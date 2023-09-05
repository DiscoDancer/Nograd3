using Nograd.ProductServices.KafkaMessages;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.KafkaConsumer
{
    public interface IMessageHandler
    {
        Task Handle(BaseMessage message);
    }
}
