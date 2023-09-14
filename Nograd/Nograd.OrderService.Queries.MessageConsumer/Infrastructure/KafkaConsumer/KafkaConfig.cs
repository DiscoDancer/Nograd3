using Confluent.Kafka;

namespace Nograd.OrderService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;

public sealed class KafkaConfig
{
    public ConsumerConfig? ConsumerConfig { get; set; }
    public string? OrderTopic { get; set; }
    public string? ProductTopic { get; set; }
}