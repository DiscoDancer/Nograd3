using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nograd.OrderService.Queries.Persistence.Entities;

#pragma warning disable CS8618

[Table("Orders")]
public class OrderEntity
{
    [Key] public Guid OrderId { get; set; }
    public bool IsShipped { get; set; }
    public bool IsGift { get; set; }
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public List<ProductQuantityEntity> ProductQuantities { get; set; }
}