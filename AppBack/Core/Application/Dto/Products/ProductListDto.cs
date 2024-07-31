﻿using AppBack.Core.Domain;

namespace AppBack.Core.Application.Dto.Products
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
