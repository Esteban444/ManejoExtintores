using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class Inventories
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string IdInventory { get; set; }
        public string? IdProduct { get; set; }
        public string? IdExtinguisherType { get; set; }
        public string? IdExtinguisherWeight { get; set; }
        //[DataType(DataType.Date)]
        public DateTime? Date { get; set; } 
        public string? Description { get; set; }
        public int? Amount { get; set; }
        //[DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; } 
        public string? IdServiceDetail { get; set; }

        public Products? Product { get; set; }
        public ServiceDetails? ServiceDeatail { get; set; }
        public WeightExtinguishers? WeightExtinguisher { get; set; }
        public TypeExtinguishers? TypeExtinguisher { get; set; } 
    }
}
