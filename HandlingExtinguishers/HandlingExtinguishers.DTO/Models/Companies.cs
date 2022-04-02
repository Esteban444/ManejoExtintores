using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class Companies: BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid IdCompany { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Nit { get; set; }
        public bool Active { get; set; }

        public ICollection<Employees>? Employees { get; set; }
    }
}
