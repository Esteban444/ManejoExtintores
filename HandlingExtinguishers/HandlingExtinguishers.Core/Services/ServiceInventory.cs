using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request.Inventories;
using HandlingExtinguishers.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingExtinguishers.Core.Services
{
    public class ServiceInventory : IInventoryService
    {
        private readonly IRepositoryInventory _repositoryInventory;
        private readonly IMapper _mapper;
        public ServiceInventory(IRepositoryInventory repository, IMapper mapper)
        {
            _repositoryInventory = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<InventoryResponseDto>> GetAllInventories()
        {
            var inventories = await _repositoryInventory.FindBy(x => x.Active).Include(x => x.Product). Include(x => x.TypeExtinguisher).
                Include(x => x.WeightExtinguisher).ToListAsync();
            var response = _mapper.Map<IEnumerable<InventoryResponseDto>>(inventories);
            return response;
        }

        public async Task<InventoryResponseDto> GetInventoryById(Guid inventoryId)
        {
            var product = await _repositoryInventory.FindBy(x => x.Active && x.Id == inventoryId).Include(x => x.Product).Include(x => x.TypeExtinguisher).
                Include(x => x.WeightExtinguisher).FirstOrDefaultAsync();
            if (product == null) throw new GlobalException("The inventory record does not exist in the database.", HttpStatusCode.NotFound);
            var response = _mapper.Map<InventoryResponseDto>(product);
            return response;
        }

        public async Task<InventoryResponseDto> AddAsync(InventoryRequestDto inventoryRequest)
        {
            if (inventoryRequest.Active != null) inventoryRequest.Active = true;
            var inventory = _mapper.Map<InventoryTable>(inventoryRequest);
            await _repositoryInventory.Add(inventory);
            var response = _mapper.Map<InventoryResponseDto>(inventory);
            return response;
        }

        public async Task<InventoryResponseDto> UpdateInventory(Guid inventoryId, InventoryRequestDto inventoryRequest)
        {
            if (inventoryRequest.Active != null) inventoryRequest.Active = true;
            var inventory = await _repositoryInventory.FindBy(x => x.Active && x.Id == inventoryId).FirstOrDefaultAsync();
            if (inventory == null) throw new GlobalException("The inventory record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            _mapper.Map(inventoryRequest, inventory);

            await _repositoryInventory.Update(inventory);
            var response = _mapper.Map<InventoryResponseDto>(inventory);
            return response;
        }

        public async Task<InventoryResponseDto> UpdateInventoryField(Guid inventoryId, InventoryRequestFieldDto inventoryRequestField)
        {
            var inventory = await _repositoryInventory.FindBy(c => c.Active && c.Id == inventoryId).FirstOrDefaultAsync();
            if (inventory == null) throw new GlobalException("The inventory record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            var properties = new UpdateMapperProperties<InventoryTable, InventoryRequestFieldDto>();
            var update = await properties.MapperUpdate(inventory!, inventoryRequestField);
            await _repositoryInventory.Update(update);
            var response = _mapper.Map<InventoryResponseDto>(update);
            return response;
        }

        public async Task<InventoryResponseDto> DeleteInventory(Guid inventoryId) 
        {
            var inventory = await _repositoryInventory.FindBy(c => c.Id == inventoryId).FirstOrDefaultAsync();
            if (inventory == null) throw new GlobalException("The inventory record you are trying to delete does not exist in the database.", HttpStatusCode.NotFound);

            if (inventory.Active == true)
            {
                inventory.Active = false;
            }
            else
            {
                inventory.Active = true;
            }
            await _repositoryInventory.Update(inventory);
            var response = _mapper.Map<InventoryResponseDto>(inventory);
            return response;
        }

    }
}
