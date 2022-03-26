using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class WeightExtinguishers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string IdExtinguisherWeight { get; set; }
        public int? WeightPound { get; set; }  

        public ICollection<ServiceDetails>? ServicesDetails { get; set; }
        public ICollection<Inventories>? Inventories { get; set; }
        public ICollection<Products>? Products { get; set; }
    }
}
