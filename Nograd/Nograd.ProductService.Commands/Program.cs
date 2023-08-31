using Nograd.ProductService.Commands.Features.CreateProduct;
using Nograd.ProductService.Commands.Features.RemoveProduct;
using Nograd.ProductService.Commands.Features.UpdateProduct;
using Nograd.ProductService.Commands.Infrastructure.EventStore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.UseEventStore();

builder.Services.UseCreateProductFeature();
builder.Services.UseUpdateProductFeature();
builder.Services.UseRemoveProductFeature();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapControllers();
app.Run();
