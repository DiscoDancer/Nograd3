﻿using System.Text.Json;
using System.Text.Json.Serialization;
using Nograd.ProductServices.KafkaMessages;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;

public sealed class MessageJsonConverter : JsonConverter<BaseMessage>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsAssignableFrom(typeof(BaseMessage));
    }

    public override BaseMessage? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions? options)
    {
        if (!JsonDocument.TryParseValue(ref reader, out var doc))
            throw new JsonException($"Failed to parse {nameof(JsonDocument)}!");

        if (!doc.RootElement.TryGetProperty("TypeName", out var type))
            throw new JsonException("Could not detect the Type discriminator property!");

        var typeDiscriminator = type.GetString();
        var json = doc.RootElement.GetRawText();

        return typeDiscriminator switch
        {
            nameof(ProductCreatedMessage) => JsonSerializer.Deserialize<ProductCreatedMessage>(json, options),
            nameof(ProductRemovedMessage) => JsonSerializer.Deserialize<ProductRemovedMessage>(json, options),
            nameof(ProductUpdatedMessage) => JsonSerializer.Deserialize<ProductUpdatedMessage>(json, options),
            _ => throw new JsonException($"{typeDiscriminator} is not supported yet!")
        };
    }

    public override void Write(Utf8JsonWriter writer, BaseMessage value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}