

namespace HandlingExtinguishers.DTO.Models
{
    public class PriceTable: BaseModel 
    {
        public Guid? ProductId { get; set; }
        public Guid? DetailServiceId { get; set; } = null;  
        public string? Description { get; set; }
        public decimal? Price { get; set; } 
        public decimal? Iva { get; set; }          // Send only the vat percentage number.
        public decimal? EndPrice { get; set; }    // It is not necessary to send from the frontend.
        public bool Active { get; set; }

        public ServiceDetailTable? DetailService { get; set; }
        public Products? Product { get; set; } 
    }
}
