using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class Services: BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? IdService { get; set; }
        public Guid? IdClient { get; set; }
        public Guid? IdEmployee { get; set; }
        public DateTime? DateOfService { get; set; } 
        public decimal? Value { get; set; } 
        public string? State { get; set; }
        public DateTime? ExpirationDate { get; set; } 
        public DateTime? MaintenanceDate { get; set; } 
        public decimal? InitialFee { get; set; }
        public bool Active { get; set; }

        public Clients? Client { get; set; } 
        public Employees? Employee { get; set; }
        public ICollection<CreditServices>? CreditServices { get; set; }
        public ICollection<ServiceDetails>? ServiceDetails { get; set; }
    }
}
