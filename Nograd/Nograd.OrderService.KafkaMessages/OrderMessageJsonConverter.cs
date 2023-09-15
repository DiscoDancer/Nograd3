using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nograd.OrderService.KafkaMessages;

public sealed class OrderMessageJsonConverter : JsonConverter<OrderBaseMessage>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsAssignableFrom(typeof(OrderBaseMessage));
    }

    public override OrderBaseMessage? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions? options)
    {
        if (!JsonDocument.TryParseValue(ref reader, out var doc))
            throw new JsonException($"Failed to parse {nameof(JsonDocument)}!");

        if (!doc.RootElement.TryGetProperty("TypeName", out var type))
            throw new JsonException("Could not detect the Type discriminator property!");

        var typeDiscriminator = type.GetString();
        var json = doc.RootElement.GetRawText();

        return typeDiscriminator switch
        {
            nameof(OrderCreatedMessage) => JsonSerializer.Deserialize<OrderCreatedMessage>(json, options),
            nameof(OrderRemovedMessage) => JsonSerializer.Deserialize<OrderRemovedMessage>(json, options),
            nameof(OrderUpdatedMessage) => JsonSerializer.Deserialize<OrderUpdatedMessage>(json, options),
            _ => throw new JsonException($"{typeDiscriminator} is not supported yet!")
        };
    }

    public override void Write(Utf8JsonWriter writer, OrderBaseMessage value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}