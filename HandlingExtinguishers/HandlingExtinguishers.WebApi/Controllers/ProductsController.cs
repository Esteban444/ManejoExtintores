using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Request.Products;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HandlingExtinguishers.WebApi.Controllers
{
    /// <summary>
    /// With this Api you will be able to manage products.
    /// </summary>
    [Route("api/products")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    
    public class ProductsController : ControllerBase 
    {
        private readonly IProductsService _productsService;

        /// <summary>
        /// Methodo constructor.
        /// </summary>
        /// <param name="productsService"></param>
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;

        }

        /// <summary>
        /// This endpoint returns all products.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("get-all-products")]
        [ProducesResponseType(typeof(ProductsResponseDto), 200)]
        [ProducesResponseType(typeof(ProductsResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultProducts([FromQuery] FilterProductsDto filter)
        {
            var products = await _productsService.GetAllProducts(filter);
            return Ok(products);
        }

        /// <summary>
        /// This endpoint returns a product by Id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("get-product-by/{productId}")]
        [ProducesResponseType(typeof(ProductsResponseDto), 200)]
        [ProducesResponseType(typeof(ProductsResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultProductById(Guid productId) 
        {
            var product = await _productsService.GetProductById(productId);
            return Ok(product);
        }

        /// <summary>
        /// This endpoint add a product.
        /// </summary>
        /// <param name="productRequest"></param>
        /// <returns></returns>
        [HttpPost("product")]
        [ProducesResponseType(typeof(ProductsResponseDto), 200)]
        [ProducesResponseType(typeof(ProductsResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(ProductsRequestDto productRequest)
        {
            var response = await _productsService.AddAsync(productRequest);
            return Ok(response);
        }

        /// <summary>
        /// This endpoint update a product by Id.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productRequestUpdate"></param>
        /// <returns></returns>
        [HttpPut("update-product/{productId}")] 
        [ProducesResponseType(typeof(ProductsResponseDto), 200)]
        [ProducesResponseType(typeof(ProductsResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateProducts(Guid productId, ProductsRequestDto productRequestUpdate) 
        {
            var result = await _productsService.UpdateProduct(productId, productRequestUpdate); 
            return Ok(result);

        }

        /// <summary>
        /// This endpoint update a product by Id.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productRequestField"></param>
        /// <returns></returns>
        [HttpPatch("update-fields-product/{productId}")]
        [ProducesResponseType(typeof(ProductsResponseDto), 200)]
        [ProducesResponseType(typeof(ProductsResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateProductsField(Guid productId, ProductsRequestFieldDto productRequestField)
        {
            var result = await _productsService.UpdateProductField(productId, productRequestField);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint delete a product by Id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("delete-product/{productId}")]
        [ProducesResponseType(typeof(ProductsResponseDto), 200)]
        [ProducesResponseType(typeof(ProductsResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var result = await _productsService.DeleteProduct(productId);
            return Ok(result);
        }
    }
}
