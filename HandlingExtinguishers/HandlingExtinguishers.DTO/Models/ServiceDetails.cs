using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class ServiceDetails 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string IdDetailService { get; set; }
        public string? IdService { get; set; }
        public string? IdExtinguisherType  { get; set; }
        public int? IdExtinguisherWeight { get; set; }
        public string? Description { get; set; }
        public decimal? Value { get; set; }
        public int? Amount { get; set; } 
        public decimal? Total { get; set; }

        public Services? Service { get; set; }
        public WeightExtinguishers? WeightExtinguisher { get; set; }
        public ICollection<Prices>? Prices { get; set; }
        public TypeExtinguishers? TypeExtinguisher { get; set; }
        public ICollection<Inventories>? Inventories { get; set; }
        //public ICollection<DetalleServicioDetalleClientes> DetalleServicioDetalleClientes { get; set; }
    }
}
