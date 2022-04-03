

namespace HandlingExtinguishers.DTO.Models
{
    public class TypeExtinguisher: BaseModel
    {
        public string? Type { get; set; } 
        public bool Active { get; set; }

        public ICollection<ServiceDetail>? ServiceDetails { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
        public ICollection<Products>? Products { get; set; }
    }
}
