using Nograd.ProductService.Queries.MessageConsumer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<KafkaConfig>(builder.Configuration.GetSection(nameof(KafkaConfig)));

builder.Services.AddScoped<IKafkaMessageConsumer, KafkaMessageConsumer>();

builder.Services.AddHostedService<ConsumerHostedService>();

var app = builder.Build();


app.Run();
