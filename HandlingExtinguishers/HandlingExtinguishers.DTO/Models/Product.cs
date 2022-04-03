

namespace HandlingExtinguishers.DTO.Models
{
    public class Products: BaseModel
    {
        public Guid? ExtinguisherTypeId { get; set; } 
        public Guid? ExtinguisherWeightId { get; set; }
        public string? TypeProduct { get; set; }
        public bool Active { get; set; }

        public WeightExtinguisher? WeightExtinguisher { get; set; }
        public TypeExtinguisher? TypeExtinguisher { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
        public ICollection<Price>? Prices { get; set; }
    }
}
