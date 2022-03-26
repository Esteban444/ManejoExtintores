using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class Prices
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string IdPrice { get; set; }
        public string? IdProduct { get; set; }
        public string? IdDetailService { get; set; } = null; 
        public string? Description { get; set; }
        public decimal? Value { get; set; }
        public decimal? Iva { get; set; }

        public ServiceDetails? DetailService { get; set; }
        public Products? Product { get; set; } 
    }
}
