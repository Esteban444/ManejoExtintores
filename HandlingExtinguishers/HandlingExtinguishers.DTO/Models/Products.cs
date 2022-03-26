using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class Products
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string IdProduct { get; set; }
        public string? IdExtinguisherType { get; set; }
        public string? IdExtinguisherWeight { get; set; }
        public string? TypeProduct { get; set; }

        public WeightExtinguishers? WeightExtinguisher { get; set; }
        public TypeExtinguishers? TypeExtinguisher { get; set; }
        public ICollection<Inventories>? Inventories { get; set; }
        public ICollection<Prices>? Prices { get; set; }
    }
}
