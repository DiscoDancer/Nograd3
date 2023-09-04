using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Nograd.ProductService.Commands.Domain;
using Nograd.ProductService.Commands.Domain.Events;

namespace Nograd.ProductService.Commands.Infrastructure.EventNotifications;

public sealed class EventNotificator : IEventNotificator
{
    private readonly ProducerConfig _config;
    private readonly string _topicName;
    private readonly IEventToMessageMapper _eventToMessageMapper;

    public EventNotificator(IOptions<KafkaConfig> config, IEventToMessageMapper eventToMessageMapper)
    {
        _eventToMessageMapper = eventToMessageMapper ?? throw new ArgumentNullException(nameof(eventToMessageMapper));
        if (config == null) throw new ArgumentNullException(nameof(config));
        if (string.IsNullOrWhiteSpace(config.Value.Topic)) throw new ArgumentNullException(nameof(config.Value.Topic));
        if (string.IsNullOrWhiteSpace(config.Value.Url)) throw new ArgumentNullException(nameof(config.Value.Url));

        _config = new ProducerConfig
        {
            BootstrapServers = config.Value.Url
        };
        _topicName = config.Value.Topic;
        _eventToMessageMapper = eventToMessageMapper;
    }

    public async Task Notify(BaseEvent @event)
    {
        using var producer = new ProducerBuilder<string, string>(_config)
            .SetKeySerializer(Serializers.Utf8)
            .SetValueSerializer(Serializers.Utf8)
            .Build();

        var message = _eventToMessageMapper.Map(@event);

        var eventMessage = new Message<string, string>
        {
            Key = Guid.NewGuid().ToString(),
            Value = JsonSerializer.Serialize(message, message.GetType())
        };
        var deliveryResult = await producer.ProduceAsync(_topicName, eventMessage);


        if (deliveryResult.Status == PersistenceStatus.NotPersisted)
            throw new Exception(
                $"Could not produce {@event.GetType().Name} message to topic - {_topicName} due to the following reason: {deliveryResult.Message}.");
    }
}