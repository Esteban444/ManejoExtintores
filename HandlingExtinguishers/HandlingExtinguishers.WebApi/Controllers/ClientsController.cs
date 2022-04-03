using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IServiceClients _serviceClients;


        public ClientsController(IServiceClients serviceClients)
        {
            _serviceClients = serviceClients;

        }

        [HttpGet("get-all-clients")]
        [ProducesResponseType(typeof(ClientResponseDto), 200)]
        [ProducesResponseType(typeof(ClientResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultClient([FromQuery] ClientFilter filter)
        {
            var clients = await _serviceClients.GetAllClients(filter);
            return Ok(clients);
        }

        [HttpGet("get-client-by/{clientId}")]
        [ProducesResponseType(typeof(ClientResponseDto), 200)]
        [ProducesResponseType(typeof(ClientResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultClientById(Guid clientId)
        {
            var client = await _serviceClients.GetClientById(clientId);
            return Ok(client);
        }

        [HttpPost("client")]
        [ProducesResponseType(typeof(ClientResponseDto), 200)]
        [ProducesResponseType(typeof(ClientResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(ClientRequestDto clientRequest)
        {
            var response = await _serviceClients.AddAsync(clientRequest);
            return Ok(response);
        }

        [HttpPut("update-client/{clientId}")]
        [ProducesResponseType(typeof(ClientResponseDto), 200)]
        [ProducesResponseType(typeof(ClientResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateClient(Guid clientId, ClientRequestDto clientRequestUpdate)
        {
            var result = await _serviceClients.UpdateClient(clientId, clientRequestUpdate);
            return Ok(result);

        }

        [HttpPatch("update-fields-client/{clientId}")]
        [ProducesResponseType(typeof(ClientResponseDto), 200)]
        [ProducesResponseType(typeof(ClientResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateClientField(Guid clientId, ClientRequestUpdateFieldDto ClientRequestField)
        {
            var result = await _serviceClients.UpdateClientField(clientId, ClientRequestField);
            return Ok(result);

        }

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
