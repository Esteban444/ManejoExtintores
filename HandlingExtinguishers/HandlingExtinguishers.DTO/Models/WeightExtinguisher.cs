

namespace HandlingExtinguishers.DTO.Models
{
    public class WeightExtinguisher: BaseModel
    {
        public int? WeightPound { get; set; }
        public bool Active { get; set; }

        public ICollection<ServiceDetail>? ServicesDetails { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
        public ICollection<Products>? Products { get; set; }
    }
}
