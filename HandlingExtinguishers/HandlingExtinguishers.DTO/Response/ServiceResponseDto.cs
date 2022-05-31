using HandlingExtinguishers.DTO.Models;

namespace HandlingExtinguishers.DTO.Response
{
    public class ServiceResponseDto: BaseModel
    {
        public Guid? ClientId { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime? DateOfService { get; set; }
        public string? State { get; set; }
        public bool Active { get; set; }
    }
}
