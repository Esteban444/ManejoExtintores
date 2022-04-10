using HandlingExtinguishers.DTO.Models;

namespace HandlingExtinguishers.DTO.Response
{
    public class PriceResponseDto: BaseModel
    {
        public Guid? ProductId { get; set; }
        public Guid? DetailServiceId { get; set; } = null;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Iva { get; set; }
        public decimal? EndPrice { get; set; }
        public bool? Active { get; set; }
    }
}
