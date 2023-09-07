namespace Nograd.OrderService.Commands.Features.CreateOrder
{
    public static class ServiceExtensions
    {
        public static void UseCreateOrderFeature(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICreateOrderControllerInputToCommandMapper, CreateOrderControllerInputToCommandMapper>();
        }
    }
}
