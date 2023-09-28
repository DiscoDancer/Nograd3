using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nograd.Clients.CustomerApp.Models.Cart;
using System.ComponentModel.DataAnnotations;

namespace Nograd.Clients.CustomerApp.Models.Order;

public sealed class OrderViewModel
{
    [BindNever] public Guid OrderID { get; set; }
    [BindNever] public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

    [Required(ErrorMessage = "Please enter a name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please enter the first address line")]
    public string? Line1 { get; set; }

    public string? Line2 { get; set; }
    public string? Line3 { get; set; }

    [Required(ErrorMessage = "Please enter a city name")]
    public string? City { get; set; }

    [Required(ErrorMessage = "Please enter a state name")]
    public string? State { get; set; }

    public string? Zip { get; set; }

    [Required(ErrorMessage = "Please enter a country name")]
    public string? Country { get; set; }

    public bool GiftWrap { get; set; }

    [BindNever] public bool Shipped { get; set; }
}