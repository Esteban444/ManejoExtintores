using HandlingExtinguishers.DTO.Request.WeightExtinguisher;
using HandlingExtinguishers.DTO.Response;


namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceWeightExtinguishers 
    {
        Task<IEnumerable<WeightExtinguisherResponseDto>> GetAllWeight();
        Task<WeightExtinguisherResponseDto> GetWeightById(Guid weightId); 
        Task<WeightExtinguisherResponseDto> AddAsync(WeightExtinguisherRequestDto weightExtinguisherRequest);
        Task<WeightExtinguisherResponseDto> UpdateWeight(Guid weightId, WeightExtinguisherRequestDto weightExtinguisherRequest); 
        Task<WeightExtinguisherResponseDto> UpdateWeightField(Guid weightId, WeightExtinguisherFieldRequestDto weightExtinguisherFieldRequest);
        Task<WeightExtinguisherResponseDto> DeleteWeight(Guid weightId);
    }
}
