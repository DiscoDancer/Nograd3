using Nograd.ProductService.Commands.Domain;
using Nograd.ProductService.Events;

namespace Nograd.ProductService.Commands.Infrastructure.EventStore
{
    public static class EventApplicator
    {
        public static void ApplyEvent(Product product, BaseEvent @event)
        {
            var method = typeof(Product).GetMethod("Apply", new Type[] { @event.GetType() });
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method), $"The Apply method was not found for {@event.GetType().Name}!");
            }

            method.Invoke(product, new object[] { @event });
        }
    }
}
