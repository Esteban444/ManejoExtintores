using HandlingExtinguishers.DTO.Request.Inventories;
using HandlingExtinguishers.DTO.Response;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryResponseDto>> GetAllInventories();
        Task<InventoryResponseDto> GetInventoryById(Guid inventoryId);
        Task<InventoryResponseDto> AddAsync(InventoryRequestDto inventoryRequest);
        Task<InventoryResponseDto> UpdateInventory(Guid inventoryId, InventoryRequestDto inventoryRequest);
        Task<InventoryResponseDto> UpdateInventoryField(Guid inventoryId, InventoryRequestFieldDto inventoryRequestField);
        Task<InventoryResponseDto> DeleteInventory(Guid inventoryId);  
    }
}
