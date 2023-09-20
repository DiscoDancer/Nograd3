using Nograd.Libraries.AspNetCoreExtensions;
using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.HideEndpointsFromOtherAssemblies(typeof(Program)));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.UseGetAllOrdersFeature();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();