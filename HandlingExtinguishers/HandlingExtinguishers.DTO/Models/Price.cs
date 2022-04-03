

namespace HandlingExtinguishers.DTO.Models
{
    public class Price: BaseModel
    {
        public Guid? ProductId { get; set; }
        public Guid? DetailServiceId { get; set; } = null;  
        public string? Description { get; set; }
        public decimal? Value { get; set; }
        public decimal? Iva { get; set; }
        public bool Active { get; set; }

        public ServiceDetail? DetailService { get; set; }
        public Products? Product { get; set; } 
    }
}
