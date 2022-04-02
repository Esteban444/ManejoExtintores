using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class WeightExtinguishers: BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? IdExtinguisherWeight { get; set; }
        public int? WeightPound { get; set; }
        public bool Active { get; set; }

        public ICollection<ServiceDetails>? ServicesDetails { get; set; }
        public ICollection<Inventories>? Inventories { get; set; }
        public ICollection<Products>? Products { get; set; }
    }
}
