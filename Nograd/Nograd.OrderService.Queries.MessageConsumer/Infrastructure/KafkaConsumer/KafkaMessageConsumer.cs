using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Nograd.OrderService.KafkaMessages;
using Nograd.OrderService.Queries.MessageConsumer.Infrastructure.KafkaConsumer.Order;

namespace Nograd.OrderService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;

public sealed class KafkaMessageConsumer : IKafkaMessageConsumer
{
    private readonly ConsumerConfig _consumerConfig;
    private readonly string _orderTopicName;
    private readonly string _productTopicName;
    private readonly IOrderMessageHandler _messageHandler;

    public KafkaMessageConsumer(
        IOptions<KafkaConfig> config,
        IOrderMessageHandler messageHandler)
    {
        if (config == null) throw new ArgumentNullException(nameof(config));
        if (string.IsNullOrWhiteSpace(config.Value.OrderTopic)) throw new ArgumentNullException(nameof(config.Value.OrderTopic));
        if (string.IsNullOrWhiteSpace(config.Value.ProductTopic)) throw new ArgumentNullException(nameof(config.Value.ProductTopic));

        _consumerConfig = config.Value.ConsumerConfig ??
                          throw new ArgumentNullException(nameof(config.Value.ConsumerConfig));
        _orderTopicName = config.Value.OrderTopic;
        _productTopicName = config.Value.ProductTopic;
        _messageHandler = messageHandler ?? throw new ArgumentNullException(nameof(messageHandler));
    }

    public void Consume()
    {
        using var consumer = new ConsumerBuilder<string, string>(_consumerConfig)
            .SetKeyDeserializer(Deserializers.Utf8)
            .SetValueDeserializer(Deserializers.Utf8)
            .Build();

        consumer.Subscribe(new[] { _orderTopicName, _productTopicName });

        while (true)
        {
            var consumeResult = consumer.Consume();
            if (consumeResult?.Message == null) continue;

            if (consumeResult.Topic == _orderTopicName)
            {
                var options = new JsonSerializerOptions { Converters = { new OrderMessageJsonConverter() } };
                var message = JsonSerializer.Deserialize<OrderBaseMessage>(consumeResult.Message.Value, options);
                if (message == null) throw new Exception("Failed to serialized a message");
                _messageHandler.HandleAsync(message);

                consumer.Commit(consumeResult);
            }
            else if (consumeResult.Topic == _productTopicName)
            {
                throw new NotImplementedException("Not supported case");
            }
            else
            {
                throw new NotImplementedException("Not supported case");
            }
        }
    }
}