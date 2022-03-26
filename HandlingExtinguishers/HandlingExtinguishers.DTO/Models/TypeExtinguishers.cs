using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class TypeExtinguishers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string IdExtinguisherType { get; set; }
        public string? TypeExtinguisher { get; set; } 

        public ICollection<ServiceDetails>? ServiceDetails { get; set; }
        public ICollection<Inventories>? Inventories { get; set; }
        public ICollection<Products>? Products { get; set; }
    }
}
