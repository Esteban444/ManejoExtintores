using System;

namespace HandlingExtinguishers.DTO.Request.Services
{
    public class ServicesRequestFieldDto
    {
        public Guid? ClientId { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime? DateOfService { get; set; }
        public string? State { get; set; }
        public bool? Active { get; set; }
    }
}
