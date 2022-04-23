using HandlingExtinguishers.DTO.Models;

namespace HandlingExtinguishers.DTO.Response 
{
    public class TypeExtinguisherResponseDto: BaseModel
    {
        public string? TypeExtinguisher { get; set; } 
        public bool? Active { get; set; }
    }
}
