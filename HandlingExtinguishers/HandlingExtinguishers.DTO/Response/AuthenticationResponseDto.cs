using System;

namespace HandlingExtinguishers.DTO.Response
{
    public class AuthenticationResponseDto
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? Expiration { get; set; }

    }
}
