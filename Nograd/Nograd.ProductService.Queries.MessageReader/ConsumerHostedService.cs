using Microsoft.Extensions.Options;

namespace Nograd.ProductService.Queries.MessageConsumer
{
    public sealed class ConsumerHostedService: IHostedService
    {
        private readonly ILogger<ConsumerHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly string _topicName;

        public ConsumerHostedService(ILogger<ConsumerHostedService> logger, IServiceProvider serviceProvider, IOptions<KafkaConfig> config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            if (config == null) throw new ArgumentNullException(nameof(config));
            if (string.IsNullOrWhiteSpace(config.Value.Topic)) throw new ArgumentNullException(nameof(config.Value.Topic));
            _topicName = config.Value.Topic;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kafka message consumer service running.");

            using (var scope = _serviceProvider.CreateScope())
            {
                var eventConsumer = scope.ServiceProvider.GetRequiredService<IKafkaMessageConsumer>();

                Task.Run(() => eventConsumer.Consume(_topicName), cancellationToken);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kafka message consumer service stopped.");

            return Task.CompletedTask;
        }
    }
}
