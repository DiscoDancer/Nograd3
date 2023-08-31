using Nograd.ProductService.Commands.Domain.Events;

namespace Nograd.ProductService.Commands.Domain
{
    public static class EventApplicator
    {
        public static Product ApplyEvent(Product product, BaseEvent @event)
        {
            var method = typeof(Product).GetMethod("Apply", new Type[] { @event.GetType() });
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method), $"The Apply method was not found for {@event.GetType().Name}!");
            }

            var result = (Product?)method.Invoke(product, new object[] { @event }) ??
                         throw new Exception("Event application failed");

            return result;
        }

        public static Product RestoreFromEvents(IEnumerable<BaseEvent> events)
        {
            var product = Product.GetNotCreatedProduct();
            foreach (var @event in events)
            {
                product = EventApplicator.ApplyEvent(product, @event);
            }
            return product;
        }
    }
}
