

namespace HandlingExtinguishers.DTO.Models
{
    public class ServiceDetailtTable : BaseModel 
    {
        public Guid? ServiceId { get; set; }
        public Guid? ProductId { get; set; } 
        public Guid? ExtinguisherTypeId  { get; set; }
        public Guid? ExtinguisherWeightId { get; set; } 
        public Guid? PriceId { get; set; }  
        public string? Description { get; set; }
        public decimal? Value { get; set; }
        public int? Amount { get; set; } 
        public decimal? Total { get; set; }
        public bool Active { get; set; }

        public ServiceTable? Service { get; set; }
        public WeightExtinguisherTable? WeightExtinguisher { get; set; }
        public PriceTable? Price { get; set; }
        public TypeExtinguisherTable? TypeExtinguisher { get; set; }
        public ProductTable? Product { get; set; } 
       
    }
}
