using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class Inventories: BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? IdInventory { get; set; }
        public Guid? IdProduct { get; set; }
        public Guid? IdExtinguisherType { get; set; }
        public Guid? IdExtinguisherWeight { get; set; }
        //[DataType(DataType.Date)]
        public DateTime? Date { get; set; } 
        public string? Description { get; set; }
        public int? Amount { get; set; }
        //[DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; } 
        public Guid? IdServiceDetail { get; set; }
        public bool Active { get; set; }

        public Products? Product { get; set; }
        public ServiceDetails? ServiceDeatail { get; set; }
        public WeightExtinguishers? WeightExtinguisher { get; set; }
        public TypeExtinguishers? TypeExtinguisher { get; set; } 
    }
}
