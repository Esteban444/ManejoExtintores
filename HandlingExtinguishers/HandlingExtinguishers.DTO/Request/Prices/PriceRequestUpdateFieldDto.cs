using System;

namespace HandlingExtinguishers.DTO.Request.Prices
{
    public class PriceRequestUpdateFieldDto 
    {
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public decimal? Iva { get; set; }       // Send only the vat percentage number.
        public bool? Active { get; set; }
    }
}
