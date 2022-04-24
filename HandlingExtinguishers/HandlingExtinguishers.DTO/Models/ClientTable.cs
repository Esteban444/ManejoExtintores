

namespace HandlingExtinguishers.DTO.Models 
{
    public class ClientTable: BaseModel
    {
        public decimal? ClientDocument { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? MobilePhone { get; set; } 
        public string? Email { get; set; }
        public string? Nit { get; set; }
        public bool Active { get; set; }
        public ICollection<CreditServiceTable>? CreditServices { get; set; } 
        public ICollection<ServiceTable>? Services { get; set; }
    }
}
