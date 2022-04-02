using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class Prices: BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? IdPrice { get; set; }
        public Guid? IdProduct { get; set; }
        public Guid? IdDetailService { get; set; } = null; 
        public string? Description { get; set; }
        public decimal? Value { get; set; }
        public decimal? Iva { get; set; }
        public bool Active { get; set; }

        public ServiceDetails? DetailService { get; set; }
        public Products? Product { get; set; } 
    }
}
