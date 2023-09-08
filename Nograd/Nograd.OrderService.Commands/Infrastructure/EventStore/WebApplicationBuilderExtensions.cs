using MongoDB.Bson.Serialization;
using Nograd.OrderService.Commands.Domain;
using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Infrastructure.EventStore;

public static class WebApplicationBuilderExtensions
{
    public static void UseEventStore(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection(nameof(MongoDbConfig)));

        BsonClassMap.RegisterClassMap<BaseEvent>();
        BsonClassMap.RegisterClassMap<OrderCreatedEvent>();
        BsonClassMap.RegisterClassMap<OrderUpdatedEvent>();
        BsonClassMap.RegisterClassMap<OrderRemovedEvent>();

        builder.Services.AddScoped<IEventStore, EventStore>();
    }
}