using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Nograd.ProductService.Commands.Domain;
using Nograd.ProductService.Events;

namespace Nograd.ProductService.Commands.Infrastructure.EventStore
{
    public sealed class EventStore : IEventStore
    {
        public const int InitialVersion = 1;
        private readonly IMongoCollection<EventModel> _eventStoreCollection;

        public EventStore(IOptions<MongoDbConfig> config)
        {
            var mongoClient = new MongoClient(config.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(config.Value.Database);

            _eventStoreCollection = mongoDatabase.GetCollection<EventModel>(config.Value.Collection);
        }

        public async Task SaveEventAsync(ProductCreatedEvent @event)
        {
            var eventModel = new EventModel
            {
                TimeStamp = DateTime.Now,
                ProductId = @event.ProductId,
                Version = InitialVersion,
                EventType = @event.GetType().Name,
                EventData = @event
            };

            await _eventStoreCollection.InsertOneAsync(eventModel).ConfigureAwait(false);
        }

        public async Task<List<BaseEvent>> GetEventsAsync(Guid productId)
        {
            var rawRows = await _eventStoreCollection
                .Find(x => x.ProductId == productId)
                .ToListAsync();

            return rawRows.OrderBy(x => x.Version).Select(x => x.EventData).ToList();
        }
    }
}
