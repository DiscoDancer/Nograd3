namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure.KafkaConsumer
{
    public static class WebApplicationBuilderExtensions
    {
        public static void UseKafkaConsumer(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<KafkaConfig>(builder.Configuration.GetSection(nameof(KafkaConfig)));

            builder.Services.AddScoped<IKafkaMessageConsumer, KafkaMessageConsumer>();
            builder.Services.AddScoped<IMessageHandler, MessageHandler>();
        }
    }
}
