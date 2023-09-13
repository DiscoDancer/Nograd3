using Nograd.OrderService.Queries.MessageConsumer;
using Nograd.OrderService.Queries.MessageConsumer.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.UseInfrastructure();
builder.Services.AddHostedService<ConsumerHostedService>();

var app = builder.Build();
app.Run();