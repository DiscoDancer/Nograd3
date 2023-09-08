namespace Nograd.OrderService.Commands.Infrastructure.EventNotifications;

public sealed class KafkaConfig
{
    public string? Url { get; set; }
    public string? Topic { get; set; }
}