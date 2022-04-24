using HandlingExtinguishers.DTO.Models;

namespace HandlingExtinguishers.DTO.Response
{
    public class WeightExtinguisherResponseDto: BaseModel
    {
        public int? WeightPound { get; set; }
        public bool? Active { get; set; }
    }
}
