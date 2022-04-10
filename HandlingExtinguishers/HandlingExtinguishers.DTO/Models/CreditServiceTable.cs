
namespace HandlingExtinguishers.DTO.Models
{
    public class CreditServiceTable: BaseModel
    {
        public Guid? ServiceId { get; set; }  
        public decimal? InitialFee { get; set; }
        public decimal? Debt { get; set; } 
        public DateTime? Date { get; set; }
        public bool Active { get; set; }

        public ServiceTable? Service { get; set; }
    }
}
