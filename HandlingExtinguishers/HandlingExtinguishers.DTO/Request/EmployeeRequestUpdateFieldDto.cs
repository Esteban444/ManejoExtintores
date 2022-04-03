﻿using System;

namespace HandlingExtinguishers.DTO.Request
{
    public class EmployeeRequestUpdateFieldDto
    {
        public Guid? CompanyId { get; set; } 
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Salary { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }
        public bool? Active { get; set; }
    }
}
