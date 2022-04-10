

namespace HandlingExtinguishers.DTO.Models
{
    public class TypeExtinguisherTable: BaseModel
    {
        public string? Type { get; set; } 
        public bool Active { get; set; }

        public ICollection<ServiceDetailTable>? ServiceDetails { get; set; }
        public ICollection<InventoryTable>? Inventories { get; set; }
        public ICollection<Products>? Products { get; set; }
    }
}
