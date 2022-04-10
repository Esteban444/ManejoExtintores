

namespace HandlingExtinguishers.DTO.Models
{
    public class WeightExtinguisherTable: BaseModel
    {
        public int? WeightPound { get; set; }
        public bool Active { get; set; }

        public ICollection<ServiceDetailTable>? ServicesDetails { get; set; }
        public ICollection<InventoryTable>? Inventories { get; set; }
        public ICollection<Products>? Products { get; set; }
    }
}
