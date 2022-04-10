

namespace HandlingExtinguishers.DTO.Models
{
    public class CompanyTable: BaseModel 
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Nit { get; set; }
        public bool Active { get; set; }

        public ICollection<EmployeeTable>? Employees { get; set; }
    }
}
