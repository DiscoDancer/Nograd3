using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Nograd.ProductService.Queries.Client;

public static class WebApplicationBuilderExtensions
{
    public static void UseProductQueriesClient(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductQueriesClient, ProductQueriesClient>();
    }
}