using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class TypeExtinguishers: BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? IdExtinguisherType { get; set; }
        public string? TypeExtinguisher { get; set; }
        public bool Active { get; set; }

        public ICollection<ServiceDetails>? ServiceDetails { get; set; }
        public ICollection<Inventories>? Inventories { get; set; }
        public ICollection<Products>? Products { get; set; }
    }
}
