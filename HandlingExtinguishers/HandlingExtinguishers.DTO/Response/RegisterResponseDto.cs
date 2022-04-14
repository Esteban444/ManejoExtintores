using System;

namespace HandlingExtinguishers.DTO.Response
{
    public class RegisterResponseDto
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}
