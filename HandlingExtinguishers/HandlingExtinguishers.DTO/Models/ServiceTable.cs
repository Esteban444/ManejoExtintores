

namespace HandlingExtinguishers.DTO.Models
{
    public class ServiceTable: BaseModel
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

        public ClientTable? Client { get; set; } 
        public EmployeeTable? Employee { get; set; }
        public ICollection<CreditServiceTable>? CreditServices { get; set; }
        public ICollection<ServiceDetailTable>? ServiceDetails { get; set; }
    }
}
