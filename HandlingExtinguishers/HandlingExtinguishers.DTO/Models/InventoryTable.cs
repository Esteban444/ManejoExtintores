

namespace HandlingExtinguishers.DTO.Models
{
    public class InventoryTable: BaseModel
    {
        public Guid? ProductId { get; set; }
        public Guid? ExtinguisherTypeId { get; set; }
        public Guid? ExtinguisherWeightId { get; set; }
        public DateTime? Date { get; set; }  
        public string? Description { get; set; }
        public int? Amount { get; set; }
        public DateTime? ExpirationDate { get; set; } 
        public bool Active { get; set; }

        public ProductTable? Product { get; set; } 
        public WeightExtinguisherTable? WeightExtinguisher { get; set; }
        public TypeExtinguisherTable? TypeExtinguisher { get; set; } 
    }
}
