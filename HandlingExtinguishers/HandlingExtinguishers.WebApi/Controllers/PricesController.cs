using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Request.Prices;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    /// <summary>
    /// With this Api you will be able to manage prices.
    /// </summary>
    [Route("api/prices")]
    [ApiController]

    public class PricesController : ControllerBase
    {
        private readonly IServicePrices _servicePrices;

        /// <summary>
        /// Methodo constructor.
        /// </summary>
        /// <param name="servicePrices"></param>
        public PricesController(IServicePrices servicePrices)
        {
            _servicePrices = servicePrices;

        }

        /// <summary>
        /// This endpoint returns all prices.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-prices")]
        [ProducesResponseType(typeof(PriceResponseDto), 200)]
        [ProducesResponseType(typeof(PriceResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultPrices()
        {
            var prices = await _servicePrices.GetAllPrices();
            return Ok(prices);
        }

        /// <summary>
        /// This endpoint returns a price by Id.
        /// </summary>
        /// <param name="priceId"></param>
        /// <returns></returns>
        [HttpGet("get-price-by/{priceId}")]
        [ProducesResponseType(typeof(PriceResponseDto), 200)]
        [ProducesResponseType(typeof(PriceResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultPriceById(Guid priceId)
        {
            var price = await _servicePrices.GetPriceById(priceId);
            return Ok(price);
        }

        /// <summary>
        /// This endpoint add a price.
        /// </summary>
        /// <param name="priceRequest"></param>
        /// <returns></returns>
        [HttpPost("price")]
        [ProducesResponseType(typeof(PriceResponseDto), 200)]
        [ProducesResponseType(typeof(PriceResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(PriceRequestDto priceRequest)
        {
            var response = await _servicePrices.AddAsync(priceRequest);
            return Ok(response);
        }

        /// <summary>
        /// This endpoint update a price by Id.
        /// </summary>
        /// <param name="priceId"></param>
        /// <param name="RequestUpdate"></param>
        /// <returns></returns>
        [HttpPut("update-price/{priceId}")]
        [ProducesResponseType(typeof(PriceResponseDto), 200)]
        [ProducesResponseType(typeof(PriceResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdatePrice(Guid priceId, PriceRequestDto RequestUpdate)
        {
            var result = await _servicePrices.UpdatePrice(priceId, RequestUpdate);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint update a price by Id.
        /// </summary>
        /// <param name="priceId"></param>
        /// <param name="RequestField"></param>
        /// <returns></returns>
        [HttpPatch("update-fields-price/{priceId}")]
        [ProducesResponseType(typeof(PriceResponseDto), 200)]
        [ProducesResponseType(typeof(PriceResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdatePriceField(Guid priceId, PriceRequestUpdateFieldDto RequestField)
        {
            var result = await _servicePrices.UpdatePriceField(priceId, RequestField);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint delete a price by Id.
        /// </summary>
        /// <param name="priceId"></param>
        /// <returns></returns>
        [HttpDelete("delete-price/{priceId}")]
        [ProducesResponseType(typeof(PriceResponseDto), 200)]
        [ProducesResponseType(typeof(PriceResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> DeletePrice(Guid priceId)
        {
            var result = await _servicePrices.DeletePrice(priceId);
            return Ok(result);
        }
    }
}
