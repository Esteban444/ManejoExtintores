using System;


namespace HandlingExtinguishers.DTO.Response
{
    public class CompanyResponseDto
    {
        public Guid? IdCompany { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Nit { get; set; }
    }
}
