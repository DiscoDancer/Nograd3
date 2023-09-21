using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Infrastructure.EventStore
{
    public sealed class EventModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public DateTime? TimeStamp { get; set; }
        public Guid? OrderId { get; set; }
        public string? EventType { get; set; }
        public BaseEvent? EventData { get; set; }
    }
}
