using Nograd.OrderService.Commands.Client;
using Nograd.OrderService.Queries.Client;
using Nograd.ProductService.Commands.Client;
using Nograd.ProductService.Queries.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.UseProductCommandsClient();
builder.UseProductQueriesClient();
builder.UseOrderQueriesClient();
builder.UseOrderCommandsClient();

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

app.Run();