using Nograd.ProductService.Commands.Features.Base;

namespace Nograd.ProductService.Commands.Features.CreateProduct
{
    public sealed class CreateProductControllerInput: BaseControllerInput
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
    }
}
