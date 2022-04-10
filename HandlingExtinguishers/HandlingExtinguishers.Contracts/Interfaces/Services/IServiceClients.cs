using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Request.Clients;
using HandlingExtinguishers.DTO.Response;


namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceClients
    {
        Task<IEnumerable<ClientResponseDto>> GetAllClients(ClientFilter filter); 
        Task<ClientResponseDto> GetClientById(Guid clientId);
        Task<ClientResponseDto> AddAsync(ClientRequestDto clientRequest);
        Task<ClientResponseDto> UpdateClient(Guid clientId, ClientRequestDto clientRequest); 
        Task<ClientResponseDto> UpdateClientField(Guid clientId, ClientRequestUpdateFieldDto clientRequest);
        Task<ClientResponseDto> DeleteClient(Guid clientId);
    }
}
