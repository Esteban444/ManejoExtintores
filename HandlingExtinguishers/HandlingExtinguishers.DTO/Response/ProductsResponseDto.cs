using HandlingExtinguishers.DTO.Models;

namespace HandlingExtinguishers.DTO.Response
{
    public class ProductsResponseDto : BaseModel
    {
        public Guid? PriceId { get; set; }
        public string? TypeProduct { get; set; }
        public bool? Active { get; set; }

        public TypeExtinguisherResponseDto? TypeExtinguisher { get; set; }  
        public WeightExtinguisherResponseDto? WeightExtinguisher { get; set; } 
    }
}
