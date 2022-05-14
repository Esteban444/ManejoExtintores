using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Request.Inventories;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    /// <summary>
    /// With this Api you will be able to manage inventories.
    /// </summary>
    [Route("api/inventories")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InventoriesController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        /// <summary>
        /// Methodo constructor.
        /// </summary>
        /// <param name="inventory"></param>
        public InventoriesController(IInventoryService inventory)
        {
            _inventoryService = inventory;
        }

        /// <summary>
        /// This endpoint returns all inventories.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-inventories")]
        [ProducesResponseType(typeof(InventoryResponseDto), 200)]
        [ProducesResponseType(typeof(InventoryResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultInvemtories()
        {
            var inventories = await _inventoryService.GetAllInventories();
            return Ok(inventories);
        }

        /// <summary>
        /// This endpoint returns a inventory by Id.
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <returns></returns>
        [HttpGet("get-inventory-by/{inventoryId}")]
        [ProducesResponseType(typeof(InventoryResponseDto), 200)]
        [ProducesResponseType(typeof(InventoryResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultInventoryById(Guid inventoryId)
        {
            var inventory = await _inventoryService.GetInventoryById(inventoryId);
            return Ok(inventory);
        }

        /// <summary>
        /// This endpoint add a inventory.
        /// </summary>
        /// <param name="inventoryRequest"></param>
        /// <returns></returns>
        [HttpPost("inventory")]
        [ProducesResponseType(typeof(InventoryResponseDto), 200)]
        [ProducesResponseType(typeof(InventoryResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(InventoryRequestDto inventoryRequest)
        {
            var response = await _inventoryService.AddAsync(inventoryRequest);
            return Ok(response);
        }

        /// <summary>
        /// This endpoint update a inventory by Id.
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <param name="inventoryRequestUpdate"></param>
        /// <returns></returns>
        [HttpPut("update-inventory/{inventoryId}")]
        [ProducesResponseType(typeof(InventoryResponseDto), 200)]
        [ProducesResponseType(typeof(InventoryResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateInventory(Guid inventoryId, InventoryRequestDto inventoryRequestUpdate)
        {
            var result = await _inventoryService.UpdateInventory(inventoryId, inventoryRequestUpdate);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint update a inventory by Id.
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <param name="inventoryRequestField"></param>
        /// <returns></returns>
        [HttpPatch("update-fields-inventory/{inventoryId}")]
        [ProducesResponseType(typeof(InventoryResponseDto), 200)]
        [ProducesResponseType(typeof(InventoryResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateInventoryField(Guid inventoryId, InventoryRequestFieldDto inventoryRequestField) 
        {
            var result = await _inventoryService.UpdateInventoryField(inventoryId, inventoryRequestField);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint delete a inventory by Id.
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <returns></returns>
        [HttpDelete("delete-inventory/{inventoryId}")]
        [ProducesResponseType(typeof(InventoryResponseDto), 200)]
        [ProducesResponseType(typeof(InventoryResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> DeleteInventory(Guid inventoryId)
        {
            var result = await _inventoryService.DeleteInventory(inventoryId); 
            return Ok(result);
        }
    }
}
