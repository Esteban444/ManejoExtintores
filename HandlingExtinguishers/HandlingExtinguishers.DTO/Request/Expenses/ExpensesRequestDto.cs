using System.ComponentModel.DataAnnotations;


namespace HandlingExtinguishers.DTO.Request.Expenses
{
    public class ExpensesRequestDto
    {
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public int? Quantity { get; set; }  
        public decimal? Total { get; set; }
        public bool? Active { get; set; }
    }
}
