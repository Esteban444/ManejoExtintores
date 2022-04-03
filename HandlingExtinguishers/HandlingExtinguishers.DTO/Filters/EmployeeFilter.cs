using System;

namespace HandlingExtinguishers.DTO.Filters
{
    public class EmployeeFilter
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
