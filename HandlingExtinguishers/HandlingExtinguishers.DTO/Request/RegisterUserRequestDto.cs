using System.ComponentModel.DataAnnotations;

namespace HandlingExtinguishers.DTO.Request
{
    public class RegisterUserRequestDto
    {
        [Required(ErrorMessage = "The names field cannot be empty.")]
        public string? Name { get; set; }
        public string? SecondName { get; set; }  

        [Required(ErrorMessage = "The lastName field cannot be empty.")]
        public string? LastName { get; set; } 
        public string? SecondLastName { get; set; }   
        public string? Email { get; set; }
        [Required(ErrorMessage = "The userName field cannot be empty.")]
        public string? UserName { get; set; }
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
