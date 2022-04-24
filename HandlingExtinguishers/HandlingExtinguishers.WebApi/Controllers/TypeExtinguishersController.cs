using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Request.TypeExtinguisher;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    /// <summary>
    /// With this Api you will be able to manage type extinguisher.
    /// </summary>

    [Route("api/typeextinguisher")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TypeExtinguishersController : ControllerBase
    {
        private readonly IServiceTypeExtinguishers _typeExtinguishers;
        /// <summary>
        /// Methodo constructor.
        /// </summary>
        public TypeExtinguishersController(IServiceTypeExtinguishers typeExtinguishers)
        {
            _typeExtinguishers = typeExtinguishers;
        }
        /// <summary>
        /// This endpoint returns all type extinguishers.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-type-extinguishers")]
        [ProducesResponseType(typeof(TypeExtinguisherResponseDto), 200)]
        [ProducesResponseType(typeof(TypeExtinguisherResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultTypeExtinguishers() 
        {
            var types = await _typeExtinguishers.GetAllType();
            return Ok(types);
        }

        /// <summary>
        /// This endpoint returns a type extinguisher by Id.
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpGet("get-type-extinguisher-by/{typeId}")]
        [ProducesResponseType(typeof(TypeExtinguisherResponseDto), 200)]
        [ProducesResponseType(typeof(TypeExtinguisherResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultTypeById(Guid typeId)
        {
            var type = await _typeExtinguishers.GetTypeById(typeId);
            return Ok(type);
        }

        /// <summary>
        /// This endpoint add a type extinguisher.
        /// </summary>
        /// <param name="typeRequest"></param>
        /// <returns></returns>
        [HttpPost("type-extinguisher")]
        [ProducesResponseType(typeof(TypeExtinguisherResponseDto), 200)]
        [ProducesResponseType(typeof(TypeExtinguisherResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(TypeExtinguisherRequestDto typeRequest)
        {
            var response = await _typeExtinguishers.AddAsync(typeRequest);
            return Ok(response);
        }

        /// <summary>
        /// This endpoint update a type extinguisher by Id.
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="typeRequestUpdate"></param>
        /// <returns></returns>
        [HttpPut("update-type-extinguisher/{typeId}")]
        [ProducesResponseType(typeof(TypeExtinguisherResponseDto), 200)]
        [ProducesResponseType(typeof(TypeExtinguisherResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateTypeExtinguisher(Guid typeId, TypeExtinguisherRequestDto typeRequestUpdate)
        {
            var result = await _typeExtinguishers.UpdateType(typeId, typeRequestUpdate);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint update a type extinguisher by Id.
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="typeRequestField"></param>
        /// <returns></returns>
        [HttpPatch("update-fields-type-extinguisher/{typeId}")]
        [ProducesResponseType(typeof(TypeExtinguisherResponseDto), 200)]
        [ProducesResponseType(typeof(TypeExtinguisherResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateTypeExtinguisherField(Guid typeId, TypeExtinguisherFieldRequestDto typeRequestField)
        {
            var result = await _typeExtinguishers.UpdateTypeField(typeId, typeRequestField);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint delete a type extinguisher by Id.
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpDelete("delete-type-extinguisher/{typeId}")]
        [ProducesResponseType(typeof(TypeExtinguisherResponseDto), 200)]
        [ProducesResponseType(typeof(TypeExtinguisherResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> DeleteTypeExtinguisher(Guid typeId)
        {
            var result = await _typeExtinguishers.DeleteType(typeId);
            return Ok(result);
        }
    }
}
