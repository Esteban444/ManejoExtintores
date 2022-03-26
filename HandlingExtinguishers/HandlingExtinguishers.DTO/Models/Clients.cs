using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models 
{
    public class Clients
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdClient { get; set; }
        public decimal? ClientDocument { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Nit { get; set; }

        //public ICollection<DetalleExtintorClientes> DetalleExtClientes { get; set; }
        public ICollection<Services>? Services { get; set; }
    }
}
