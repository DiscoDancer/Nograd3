namespace Nograd.ProductService.Commands.Features.Base;

public interface IControllerInputToCommandMapper<in TControllerInput, out TCommand>
    where TControllerInput : BaseControllerInput
    where TCommand : BaseCommand
{
    TCommand Map(TControllerInput input);
}