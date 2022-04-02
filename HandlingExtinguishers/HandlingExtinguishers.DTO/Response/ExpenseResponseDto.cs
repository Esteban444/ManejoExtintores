using HandlingExtinguishers.DTO.Models;

namespace HandlingExtinguishers.DTO.Response
{
    public class ExpenseResponseDto: BaseModel
    {
        public Guid IdExpense { get; set; }
        public string? Description { get; set; }
        //[DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public int? Quantity { get; set; }
        public decimal Total { get; set; }
        public bool? Active { get; set; }
    }
}
