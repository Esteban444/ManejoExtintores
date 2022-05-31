using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Request.Services;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    /// <summary>
    /// With this Api you will be able to manage services.
    /// </summary>
    [Route("api/services")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ServicesController : ControllerBase 
    {
        private readonly IService_Services _service_Services;

        /// <summary>
        /// Methodo constructor.
        /// </summary>
        /// <param name="serviceClients"></param>
        public ServicesController(IService_Services service_Services)
        {
           _service_Services = service_Services;

        }

        /// <summary>
        /// This endpoint returns all services.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("get-all-services")]
        [ProducesResponseType(typeof(ServiceResponseDto), 200)]
        [ProducesResponseType(typeof(ServiceResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultServices()
        {
            var services = await _service_Services.GetAllServices();
            return Ok(services);
        }

        /// <summary>
        /// This endpoint returns a service by Id.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpGet("get-service-by/{serviceId}")]
        [ProducesResponseType(typeof(ServiceResponseDto), 200)]
        [ProducesResponseType(typeof(ServiceResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultServiceById(Guid serviceId)
        {
            var service = await _service_Services.GetServiceById(serviceId);
            return Ok(service);
        }

        /// <summary>
        /// This endpoint add a service.
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        [HttpPost("service")]
        [ProducesResponseType(typeof(ServiceResponseDto), 200)]
        [ProducesResponseType(typeof(ServiceResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(ServiceRequestDto serviceRequest)
        {
            var response = await _service_Services.AddAsync(serviceRequest);
            return Ok(response);
        }

        /// <summary>
        /// This endpoint update a service by Id.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="serviceRequestUpdate"></param>
        /// <returns></returns>
        [HttpPut("update-service/{serviceId}")]
        [ProducesResponseType(typeof(ServiceResponseDto), 200)]
        [ProducesResponseType(typeof(ServiceResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateService(Guid serviceId, ServiceRequestDto serviceRequestUpdate)
        {
            var result = await _service_Services.UpdateService(serviceId, serviceRequestUpdate);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint update a service by Id.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="serviceRequestField"></param>
        /// <returns></returns>
        [HttpPatch("update-fields-service/{serviceId}")]
        [ProducesResponseType(typeof(ServiceResponseDto), 200)]
        [ProducesResponseType(typeof(ServiceResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateServiceField(Guid serviceId, ServicesRequestFieldDto serviceRequestField) 
        {
            var result = await _service_Services.UpdateServiceField(serviceId, serviceRequestField);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint delete a service by Id.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpDelete("delete-service/{serviceId}")]
        [ProducesResponseType(typeof(ServiceResponseDto), 200)]
        [ProducesResponseType(typeof(ServiceResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> DeleteService(Guid serviceId) 
        {
            var result = await _service_Services.DeletedService(serviceId);
            return Ok(result);
        }
    }
}
