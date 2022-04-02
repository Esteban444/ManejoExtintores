using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class CreditServices: BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? IdCredit { get; set; }
        public Guid? IdService { get; set; } 
        public decimal? InitialFee { get; set; }
        public decimal? Debt { get; set; } 
        public DateTime? Date { get; set; }
        public bool Active { get; set; }

        public Services? Service { get; set; }
    }
}
