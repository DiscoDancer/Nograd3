namespace Nograd.ProductService.Commands.Infrastructure.EventStore
{
    public sealed class MongoDbConfig
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }
}
