using Microsoft.AspNetCore.Identity;

namespace HandlingExtinguishers.DTO.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? Name { get; set; }
        public string? SecondName { get; set; }  
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; } 
    }
}
