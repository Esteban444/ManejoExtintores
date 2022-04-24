using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Request.WeightExtinguisher;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    /// <summary>
    /// With this Api you will be able to manage weight extinguisher.
    /// </summary>
    [Route("api/weightextinguishers")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WeightExtinguisHersController : ControllerBase
    {
        private readonly IServiceWeightExtinguishers _serviceWeightExtinguisHers;
        /// <summary>
        /// Methodo constructor.
        /// </summary>
        public WeightExtinguisHersController(IServiceWeightExtinguishers serviceWeightExtinguis) 
        {
            _serviceWeightExtinguisHers = serviceWeightExtinguis;
        }
        /// <summary>
        /// This endpoint returns all weight extinguishers.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-weight-extinguishers")]
        [ProducesResponseType(typeof(WeightExtinguisherResponseDto), 200)]
        [ProducesResponseType(typeof(WeightExtinguisherResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultWeightExtinguishers()
        {
            var weights = await _serviceWeightExtinguisHers.GetAllWeight();
            return Ok(weights);
        }

        /// <summary>
        /// This endpoint returns a weight extinguisher by Id.
        /// </summary>
        /// <param name="weightId"></param>
        /// <returns></returns>
        [HttpGet("get-weight-extinguisher-by/{weightId}")]
        [ProducesResponseType(typeof(WeightExtinguisherResponseDto), 200)]
        [ProducesResponseType(typeof(WeightExtinguisherResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultWeightById(Guid weightId)
        {
            var weight = await _serviceWeightExtinguisHers.GetWeightById(weightId);
            return Ok(weight);
        }

        /// <summary>
        /// This endpoint add a weight extinguisher.
        /// </summary>
        /// <param name="weightRequest"></param>
        /// <returns></returns>
        [HttpPost("weight-extinguisher")]
        [ProducesResponseType(typeof(WeightExtinguisherResponseDto), 200)]
        [ProducesResponseType(typeof(WeightExtinguisherResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(WeightExtinguisherRequestDto weightRequest)
        {
            var response = await _serviceWeightExtinguisHers.AddAsync(weightRequest);
            return Ok(response);
        }

        /// <summary>
        /// This endpoint update a weight extinguisher by Id.
        /// </summary>
        /// <param name="weightId"></param>
        /// <param name="weightRequestUpdate"></param>
        /// <returns></returns>
        [HttpPut("update-weight-extinguisher/{weightId}")]
        [ProducesResponseType(typeof(WeightExtinguisherResponseDto), 200)]
        [ProducesResponseType(typeof(WeightExtinguisherResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateWeightExtinguisher(Guid weightId, WeightExtinguisherRequestDto weightRequestUpdate) 
        {
            var result = await _serviceWeightExtinguisHers.UpdateWeight(weightId, weightRequestUpdate);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint update a weight extinguisher by Id.
        /// </summary>
        /// <param name="weightId"></param>
        /// <param name="weightRequestField"></param>
        /// <returns></returns>
        [HttpPatch("update-fields-weight-extinguisher/{weightId}")]
        [ProducesResponseType(typeof(WeightExtinguisherResponseDto), 200)]
        [ProducesResponseType(typeof(WeightExtinguisherResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateWeightExtinguisherField(Guid weightId, WeightExtinguisherFieldRequestDto weightRequestField)
        {
            var result = await _serviceWeightExtinguisHers.UpdateWeightField(weightId, weightRequestField);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint delete a weight extinguisher by Id.
        /// </summary>
        /// <param name="weightId"></param>
        /// <returns></returns>
        [HttpDelete("delete-weight-extinguisher/{weightId}")]
        [ProducesResponseType(typeof(WeightExtinguisherResponseDto), 200)]
        [ProducesResponseType(typeof(WeightExtinguisherResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> DeleteWeightExtinguisher(Guid weightId)
        {
            var result = await _serviceWeightExtinguisHers.DeleteWeight(weightId);
            return Ok(result);
        }
    }
}
