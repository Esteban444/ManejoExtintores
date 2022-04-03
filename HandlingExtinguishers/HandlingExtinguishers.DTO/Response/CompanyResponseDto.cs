﻿using HandlingExtinguishers.DTO.Models;


namespace HandlingExtinguishers.DTO.Response
{
    public class CompanyResponseDto: BaseModel
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Nit { get; set; }
        public bool? Active { get; set; }
    }
}
