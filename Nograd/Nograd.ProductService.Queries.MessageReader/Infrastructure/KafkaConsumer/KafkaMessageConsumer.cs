using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Nograd.ProductServices.KafkaMessages;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;

public sealed class KafkaMessageConsumer : IKafkaMessageConsumer
{
    private readonly ConsumerConfig _consumerConfig;
    private readonly string _topicName;
    private readonly IMessageHandler _messageHandler;

    public KafkaMessageConsumer(
        IOptions<KafkaConfig> config,
        IMessageHandler messageHandler)
    {
        if (config == null) throw new ArgumentNullException(nameof(config));
        if (string.IsNullOrWhiteSpace(config.Value.Topic)) throw new ArgumentNullException(nameof(config.Value.Topic));

        _consumerConfig = config.Value.ConsumerConfig ?? throw new ArgumentNullException(nameof(config.Value.ConsumerConfig));
        _topicName = config.Value.Topic;
        _messageHandler = messageHandler ?? throw new ArgumentNullException(nameof(messageHandler));
    }

    public void Consume()
    {
        using var consumer = new ConsumerBuilder<string, string>(_consumerConfig)
            .SetKeyDeserializer(Deserializers.Utf8)
            .SetValueDeserializer(Deserializers.Utf8)
            .Build();

        consumer.Subscribe(_topicName);

        while (true)
        {
            var consumeResult = consumer.Consume();
            if (consumeResult?.Message == null) continue;

            try
            {
                var options = new JsonSerializerOptions { Converters = { new MessageJsonConverter() } };
                var message = JsonSerializer.Deserialize<BaseMessage>(consumeResult.Message.Value, options);
                if (message == null)
                {
                    throw new Exception("Failed to serialized a message");
                }
                _messageHandler.Handle(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            consumer.Commit(consumeResult);
        }
    }
}