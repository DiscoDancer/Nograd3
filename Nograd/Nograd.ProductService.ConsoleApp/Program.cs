using Nograd.ProductService.Queries.Client;

namespace Nograd.ProductService.ConsoleApp;

public static class Program
{
    public static async Task Main()
    {
        var client = new ProductQueriesClient("http://localhost:5079");

        try
        {
            var result = await client.GetProductByIdOrDefaultAsync(Guid.Parse("C42E40F7-B175-4932-93AB-3C86E9BD7F7B"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }



        Console.WriteLine("Hello world!");
    }
}