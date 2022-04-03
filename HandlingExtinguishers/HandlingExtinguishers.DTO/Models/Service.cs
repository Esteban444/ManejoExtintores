

namespace HandlingExtinguishers.DTO.Models
{
    public class Service: BaseModel
    {
        public Guid? ClientId { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime? DateOfService { get; set; } 
        public decimal? Value { get; set; } 
        public string? State { get; set; }
        public DateTime? ExpirationDate { get; set; } 
        public DateTime? MaintenanceDate { get; set; } 
        public decimal? InitialFee { get; set; }
        public bool Active { get; set; }

        public Client? Client { get; set; } 
        public Employee? Employee { get; set; }
        public ICollection<CreditService>? CreditServices { get; set; }
        public ICollection<ServiceDetail>? ServiceDetails { get; set; }
    }
}
