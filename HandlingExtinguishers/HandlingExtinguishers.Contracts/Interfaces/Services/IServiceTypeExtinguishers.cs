using HandlingExtinguishers.DTO.Request.TypeExtinguisher;
using HandlingExtinguishers.DTO.Response;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceTypeExtinguishers
    {
        Task<IEnumerable<TypeExtinguisherResponseDto>> GetAllType();
        Task<TypeExtinguisherResponseDto> GetTypeById(Guid typeId);
        Task<TypeExtinguisherResponseDto> AddAsync(TypeExtinguisherRequestDto typeExtinguisherRequest);
        Task<TypeExtinguisherResponseDto> UpdateType(Guid typeId, TypeExtinguisherRequestDto typeExtinguisherRequest);
        Task<TypeExtinguisherResponseDto> UpdateTypeField(Guid typeId, TypeExtinguisherFieldRequestDto typeExtinguisherRequest); 
        Task<TypeExtinguisherResponseDto> DeleteType(Guid typeId); 
    }
}
