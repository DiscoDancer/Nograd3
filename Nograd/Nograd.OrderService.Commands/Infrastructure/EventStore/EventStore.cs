using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Nograd.OrderService.Commands.Domain;
using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Infrastructure.EventStore;

public sealed class EventStore : IEventStore
{
    private readonly IMongoCollection<EventModel> _eventStoreCollection;

    public EventStore(IOptions<MongoDbConfig> config)
    {
        if (config == null) throw new ArgumentNullException(nameof(config));
        if (string.IsNullOrWhiteSpace(config.Value.ConnectionString)) throw new ArgumentNullException(nameof(config.Value.ConnectionString));
        if (string.IsNullOrWhiteSpace(config.Value.Database)) throw new ArgumentNullException(nameof(config.Value.Database));
        if (string.IsNullOrWhiteSpace(config.Value.Collection)) throw new ArgumentNullException(nameof(config.Value.Collection));

        var mongoClient = new MongoClient(config.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(config.Value.Database);

        _eventStoreCollection = mongoDatabase.GetCollection<EventModel>(config.Value.Collection);
    }

    public async Task SaveEventAsync(BaseEvent @event, Guid orderId)
    {
        var eventModel = new EventModel
        {
            TimeStamp = DateTime.Now,
            ProductId = orderId,
            EventType = @event.GetType().Name,
            EventData = @event
        };

        await _eventStoreCollection.InsertOneAsync(eventModel).ConfigureAwait(false);
    }

    public async Task<List<BaseEvent>> GetEventsAsync(Guid orderId)
    {
        var rawRows = await _eventStoreCollection
            .Find(x => x.ProductId == orderId)
            .ToListAsync();

        var result = rawRows.Where(x => x.EventData != null).Select(x => x.EventData!).ToList();

        return result;
    }
}