using HandlingExtinguishers.DTO.Models;

namespace HandlingExtinguishers.DTO.Response
{
    public class ExpenseResponseDto: BaseModel
    {
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public int? Quantity { get; set; }
        public decimal Total { get; set; }
        public bool? Active { get; set; }
    }
}
