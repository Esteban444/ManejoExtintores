

namespace HandlingExtinguishers.DTO.Models
{
    public class PriceTable: BaseModel 
    { 
        public decimal? Price { get; set; } 
        public string? Description { get; set; }
        public decimal? Iva { get; set; }          // Send only the vat percentage number.
        public decimal? EndPrice { get; set; }    // It is not necessary to send from the frontend.
        public bool Active { get; set; }

        public ICollection<ProductTable>? Products { get; set; }
        public ICollection<ServiceDetailtTable>? ServiceDetailts { get; set; } 
    }
}
