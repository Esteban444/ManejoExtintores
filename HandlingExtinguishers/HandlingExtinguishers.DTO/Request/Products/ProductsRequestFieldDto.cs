using System;

namespace HandlingExtinguishers.DTO.Request.Products
{
    public class ProductsRequestFieldDto
    {
        public Guid? TypeExtinguisherId { get; set; }
        public Guid? WeightExtinguisherId { get; set; }
        public Guid? PriceId { get; set; }
        public string? TypeProduct { get; set; }
        public bool? Active { get; set; }
    }
}
