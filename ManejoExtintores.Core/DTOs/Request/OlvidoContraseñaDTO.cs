

using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.DTOs.Request
{
    public class OlvidoContraseñaDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ClientURI { get; set; }
    }
}
