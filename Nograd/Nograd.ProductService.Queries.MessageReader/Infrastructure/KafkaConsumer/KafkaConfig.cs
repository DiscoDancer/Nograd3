using Confluent.Kafka;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.KafkaConsumer
{
    public sealed class KafkaConfig
    {
        public ConsumerConfig? ConsumerConfig { get; set; }
        public string? Topic { get; set; }
    }
}
