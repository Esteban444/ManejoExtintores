using System;

namespace HandlingExtinguishers.DTO.Request.Services
{
    public class ServiceRequestDto
    {
        public Guid? ClientId { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime? DateOfService { get; set; }
        public string? State { get; set; }
        public bool? Active { get; set; }
    }
}
