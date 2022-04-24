

namespace HandlingExtinguishers.DTO.Models
{
    public class ProductTable: BaseModel 
    {
        public Guid? ExtinguisherTypeId { get; set; } 
        public Guid? ExtinguisherWeightId { get; set; }
        public Guid? PriceId { get; set; } 
        public string? TypeProduct { get; set; }
        public bool Active { get; set; }

        public WeightExtinguisherTable? WeightExtinguisher { get; set; }
        public TypeExtinguisherTable? TypeExtinguisher { get; set; }
        public ICollection<InventoryTable>? Inventories { get; set; }
        public ICollection<ServiceDetailtTable>? ServiceDetailts { get; set; } 
        public PriceTable? Price { get; set; } 
    }
}
