using System.ComponentModel.DataAnnotations;


namespace HandlingExtinguishers.DTO.Request
{
    public class ExpensesRequestUpdateFieldDto
    {
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }
    }
}
