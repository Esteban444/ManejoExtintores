
namespace HandlingExtinguishers.DTO.Models
{
    public class CreditService: BaseModel
    {
        public Guid? ServiceId { get; set; }  
        public decimal? InitialFee { get; set; }
        public decimal? Debt { get; set; } 
        public DateTime? Date { get; set; }
        public bool Active { get; set; }

        public Service? Service { get; set; }
    }
}
