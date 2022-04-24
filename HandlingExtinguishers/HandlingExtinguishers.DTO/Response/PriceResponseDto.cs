using HandlingExtinguishers.DTO.Models;

namespace HandlingExtinguishers.DTO.Response
{
    public class PriceResponseDto: BaseModel
    {
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public decimal? Iva { get; set; }
        public decimal? EndPrice { get; set; }
        public bool? Active { get; set; }
    }
}
