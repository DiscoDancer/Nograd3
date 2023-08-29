using MongoDB.Bson.Serialization;
using Nograd.ProductService.Commands.Domain;
using Nograd.ProductService.Events;

namespace Nograd.ProductService.Commands.Infrastructure.EventStore
{
    public static class WebApplicationBuilderExtensions
    {
        public static void UseEventStore(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection(nameof(MongoDbConfig)));

            BsonClassMap.RegisterClassMap<BaseEvent>();
            BsonClassMap.RegisterClassMap<ProductCreatedEvent>();
            BsonClassMap.RegisterClassMap<ProductUpdatedEvent>();
            BsonClassMap.RegisterClassMap<ProductRemovedEvent>();

            builder.Services.AddScoped<IEventStore, EventStore>();
        }
    }
}
