using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class CreditServices
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string IdCredit { get; set; }
        public string? IdService { get; set; } 
        public decimal? InitialFee { get; set; }
        public decimal? Debt { get; set; } 
        public DateTime? Date { get; set; }

        public Services? Service { get; set; }
    }
}
