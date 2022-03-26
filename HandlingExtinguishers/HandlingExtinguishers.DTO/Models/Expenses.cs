using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandlingExtinguishers.DTO.Models
{
    public class Expenses
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid IdExpense { get; set; } 
        public string? Description { get; set; }
        public DateTime? Date { get; set; } 
        public int? Quantity { get; set; } 
        public decimal? Total { get; set; }
    }
}
