using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Request.Clients;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    /// <summary>
    /// With this Api you will be able to manage clients.
    /// </summary>
    [Route("api/clients")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientsController : ControllerBase
    {
        private readonly IServiceClients _serviceClients;

        /// <summary>
        /// Methodo constructor.
        /// </summary>
        /// <param name="serviceClients"></param>
        public ClientsController(IServiceClients serviceClients)
        {
            _serviceClients = serviceClients;

        }

        /// <summary>
        /// This endpoint returns all clients.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("get-all-clients")]
        [ProducesResponseType(typeof(ClientResponseDto), 200)]
        [ProducesResponseType(typeof(ClientResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultClient([FromQuery] ClientFilter filter)
        {
            var clients = await _serviceClients.GetAllClients(filter);
            return Ok(clients);
        }

        /// <summary>
        /// This endpoint returns a client by Id.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet("get-client-by/{clientId}")]
        [ProducesResponseType(typeof(ClientResponseDto), 200)]
        [ProducesResponseType(typeof(ClientResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultClientById(Guid clientId)
        {
            var client = await _serviceClients.GetClientById(clientId);
            return Ok(client);
        }

        /// <summary>
        /// This endpoint add a client.
        /// </summary>
        /// <param name="clientRequest"></param>
        /// <returns></returns>
        [HttpPost("client")]
        [ProducesResponseType(typeof(ClientResponseDto), 200)]
        [ProducesResponseType(typeof(ClientResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(ClientRequestDto clientRequest)
        {
            var response = await _serviceClients.AddAsync(clientRequest);
            return Ok(response);
        }

        /// <summary>
        /// This endpoint update a client by Id.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientRequestUpdate"></param>
        /// <returns></returns>
        [HttpPut("update-client/{clientId}")]
        [ProducesResponseType(typeof(ClientResponseDto), 200)]
        [ProducesResponseType(typeof(ClientResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateClient(Guid clientId, ClientRequestDto clientRequestUpdate)
        {
            var result = await _serviceClients.UpdateClient(clientId, clientRequestUpdate);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint update a client by Id.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="ClientRequestField"></param>
        /// <returns></returns>
        [HttpPatch("update-fields-client/{clientId}")]
        [ProducesResponseType(typeof(ClientResponseDto), 200)]
        [ProducesResponseType(typeof(ClientResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateClientField(Guid clientId, ClientRequestUpdateFieldDto ClientRequestField)
        {
            var result = await _serviceClients.UpdateClientField(clientId, ClientRequestField);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint delete a client by Id.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpDelete("delete-client/{clientId}")]
        [ProducesResponseType(typeof(ClientResponseDto), 200)]
        [ProducesResponseType(typeof(ClientResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> DeleteClient(Guid clientId)
        {
            var result = await _serviceClients.DeleteClient(clientId);
            return Ok(result);
        }
    }
}
