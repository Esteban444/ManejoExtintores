using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class Employees: BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? IdEmployee { get; set; }
        public Guid? IdCompany { get; set; }
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
        public bool Active { get; set; }

        public Companies? Company { get; set; } 
        public ICollection<Services>? Services { get; set; } 
    }
}
