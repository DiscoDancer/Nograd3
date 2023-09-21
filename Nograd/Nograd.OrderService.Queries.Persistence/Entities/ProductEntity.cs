using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nograd.OrderService.Queries.Persistence.Entities;

#pragma warning disable CS8618

[Table("Products")]
public class ProductEntity
{
    [Key] public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}