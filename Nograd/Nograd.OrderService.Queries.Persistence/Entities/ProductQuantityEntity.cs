using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nograd.OrderService.Queries.Persistence.Entities;

#pragma warning disable CS8618

[Table("ProductQuantities")]
public class ProductQuantityEntity
{
    [Key]
    public long Id { get; set; }
    public ProductEntity Product { get; set; }
    [ForeignKey("Product")]
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public OrderEntity Order { get; set; }
}