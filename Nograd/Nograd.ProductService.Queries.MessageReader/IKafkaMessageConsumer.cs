namespace Nograd.ProductService.Queries.MessageConsumer
{
    public interface IKafkaMessageConsumer
    {
        void Consume(string topic);
    }
}
