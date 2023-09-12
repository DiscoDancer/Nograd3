using Nograd.OrderService.Queries.Persistence.Context;
using Nograd.OrderService.Queries.Persistence.Entities;
using Nograd.OrderService.Queries.Persistence.Repositories;

namespace Nograd.OrderService.ConsoleApp;

public static class Program
{
    public static async Task Main()
    {
        //var context = new DatabaseContext();

        //var readingRepository = new ReadOrderRepository(context);
        //var writingRepository = new WriteOrderRepository(context, readingRepository);

        //await writingRepository.UpdateAsync(new OrderEntity()
        //{
        //    CustomerAddress = "CustomerAddress",
        //    CustomerName = "name",
        //    IsGift = true,
        //    IsShipped = false,
        //    OrderId = Guid.Parse("C276F323-26DD-45F8-840A-6ED630C4E996"),
        //    ProductQuantities = new List<ProductQuantityEntity>()
        //    {
        //        new ProductQuantityEntity()
        //        {
        //            ProductId = new Guid(),
        //            Quantity = 422
        //        }
        //    },
        //});

        // await writingRepository.RemoveAsync(Guid.Parse("920D1141-94C1-4331-B45B-71D91FB25C70"));
    }
}