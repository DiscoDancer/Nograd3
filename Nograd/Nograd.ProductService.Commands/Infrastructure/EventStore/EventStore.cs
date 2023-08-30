using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Nograd.ProductService.Commands.Domain;
using Nograd.ProductService.Events;

namespace Nograd.ProductService.Commands.Infrastructure.EventStore
{
    public sealed class EventStore : IEventStore
    {
        private readonly IMongoCollection<EventModel> _eventStoreCollection;

        public EventStore(IOptions<MongoDbConfig> config)
        {
            var mongoClient = new MongoClient(config.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(config.Value.Database);

            _eventStoreCollection = mongoDatabase.GetCollection<EventModel>(config.Value.Collection);
        }

        public async Task SaveEventAsync(BaseEvent @event, Guid productId)
        {
            var eventModel = new EventModel
            {
                TimeStamp = DateTime.Now,
                ProductId = productId,
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

            var result = rawRows.Where(x => x.EventData != null).Select(x => x.EventData!).ToList();

            return result;
        }
    }
}
