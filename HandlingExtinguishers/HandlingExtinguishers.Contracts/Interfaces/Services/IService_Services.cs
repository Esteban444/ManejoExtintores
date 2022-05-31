using HandlingExtinguishers.DTO.Request.Services;
using HandlingExtinguishers.DTO.Response;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IService_Services 
    {
        Task<IEnumerable<ServiceResponseDto>> GetAllServices();
        Task<ServiceResponseDto> GetServiceById(Guid serviceId); 
        Task<ServiceResponseDto> AddAsync(ServiceRequestDto serviceRequest); 
        Task<ServiceResponseDto> UpdateService(Guid serviceId, ServiceRequestDto ServiceRequest); 
        Task<ServiceResponseDto> UpdateServiceField(Guid serviceId, ServicesRequestFieldDto serviceRequestField);
        Task<ServiceResponseDto> DeletedService(Guid serviceId);
    }
}
