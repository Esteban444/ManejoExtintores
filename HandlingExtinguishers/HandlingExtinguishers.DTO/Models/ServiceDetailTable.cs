

namespace HandlingExtinguishers.DTO.Models
{
    public class ServiceDetailTable : BaseModel
    {
        public Guid? ServiceId { get; set; }
        public Guid? ExtinguisherTypeId  { get; set; }
        public Guid? ExtinguisherWeightId { get; set; } 
        public string? Description { get; set; }
        public decimal? Value { get; set; }
        public int? Amount { get; set; } 
        public decimal? Total { get; set; }
        public bool Active { get; set; }

        public ServiceTable? Service { get; set; }
        public WeightExtinguisherTable? WeightExtinguisher { get; set; }
        public ICollection<PriceTable>? Prices { get; set; }
        public TypeExtinguisherTable? TypeExtinguisher { get; set; }
        public ICollection<InventoryTable>? Inventories { get; set; }
        //public ICollection<DetalleServicioDetalleClientes> DetalleServicioDetalleClientes { get; set; }
    }
}
