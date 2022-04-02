using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class Products: BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? IdProduct { get; set; }
        public Guid? IdExtinguisherType { get; set; }
        public Guid? IdExtinguisherWeight { get; set; }
        public string? TypeProduct { get; set; }
        public bool Active { get; set; }

        public WeightExtinguishers? WeightExtinguisher { get; set; }
        public TypeExtinguishers? TypeExtinguisher { get; set; }
        public ICollection<Inventories>? Inventories { get; set; }
        public ICollection<Prices>? Prices { get; set; }
    }
}
