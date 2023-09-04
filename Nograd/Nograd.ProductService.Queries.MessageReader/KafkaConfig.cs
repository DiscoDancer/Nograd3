namespace Nograd.ProductService.Queries.MessageConsumer
{
    public sealed class KafkaConfig
    {
        public string? Url { get; set; }
        public string? Topic { get; set; }
    }
}
