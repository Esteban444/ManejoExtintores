

namespace HandlingExtinguishers.DTO.Models
{
    public class TypeExtinguisherTable: BaseModel
    {
        public string? TypeExtinguisher { get; set; }  
        public bool Active { get; set; }

        public ICollection<ServiceDetailtTable>? ServiceDetailts { get; set; } 
        public ICollection<InventoryTable>? Inventories { get; set; }
        public ICollection<ProductTable>? Products { get; set; }
    }
}
