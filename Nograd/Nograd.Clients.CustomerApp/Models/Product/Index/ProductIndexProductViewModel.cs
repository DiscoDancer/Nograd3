using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nograd.Clients.CustomerApp.Models.Product.Index
{
    public sealed class ProductIndexProductViewModel
    {
        public ProductIndexProductViewModel(
            Guid? productId,
            string name,
            string description,
            decimal price,
            string category
        )
        {
            ProductID = productId;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }

        public Guid? ProductID { get; }

        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; }

        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; }

        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; }
    }
}
