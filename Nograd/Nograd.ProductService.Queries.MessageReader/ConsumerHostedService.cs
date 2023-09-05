using Nograd.ProductService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;

namespace Nograd.ProductService.Queries.MessageConsumer;

public sealed class ConsumerHostedService : IHostedService
{
    private readonly ILogger<ConsumerHostedService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public ConsumerHostedService(ILogger<ConsumerHostedService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Kafka message consumer service running.");

        using (var scope = _serviceProvider.CreateScope())
        {
            var eventConsumer = scope.ServiceProvider.GetRequiredService<IKafkaMessageConsumer>();
            Task.Run(eventConsumer.Consume, cancellationToken);
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Kafka message consumer service stopped.");

        return Task.CompletedTask;
    }
}