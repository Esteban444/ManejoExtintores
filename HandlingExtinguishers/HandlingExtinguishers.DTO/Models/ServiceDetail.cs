

namespace HandlingExtinguishers.DTO.Models
{
    public class ServiceDetail : BaseModel
    {
        public Guid? ServiceId { get; set; }
        public Guid? ExtinguisherTypeId  { get; set; }
        public Guid? ExtinguisherWeightId { get; set; } 
        public string? Description { get; set; }
        public decimal? Value { get; set; }
        public int? Amount { get; set; } 
        public decimal? Total { get; set; }
        public bool Active { get; set; }

        public Service? Service { get; set; }
        public WeightExtinguisher? WeightExtinguisher { get; set; }
        public ICollection<Price>? Prices { get; set; }
        public TypeExtinguisher? TypeExtinguisher { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
        //public ICollection<DetalleServicioDetalleClientes> DetalleServicioDetalleClientes { get; set; }
    }
}
