﻿using Nograd.ProductService.Commands.Features.Base;

namespace Nograd.ProductService.Commands.Features.CreateProduct
{
    public sealed class CreateProductCommand: BaseCommand
    {
        public CreateProductCommand(
            string name,
            string description,
            string category,
            decimal price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            if (string.IsNullOrWhiteSpace(category)) throw new ArgumentNullException(nameof(category));
            if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));

            Name = name;
            Description = description;
            Category = category;
            Price = price;
        }

        public string Name { get; }
        public string Description { get; }
        public string Category { get; }
        public decimal Price { get; }
    }
}
