namespace Nograd.OrderService.Commands.Features.CreateOrder
{
    public interface ICreateOrderControllerInputToCommandMapper
    {
        CreateOrderCommand Map(CreateOrderControllerInput input, Guid orderId);
    }
}
