using HandlingExtinguishers.DTO.Models;

namespace HandlingExtinguishers.DTO.Response
{
    public class InventoryResponseDto: BaseModel
    {
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public int? Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Active { get; set; }

        public ProductsResponseDto? Product { get; set; }
    }
}
