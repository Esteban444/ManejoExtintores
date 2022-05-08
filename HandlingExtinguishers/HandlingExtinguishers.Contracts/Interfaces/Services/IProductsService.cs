using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Request.Products;
using HandlingExtinguishers.DTO.Response;


namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductsResponseDto>> GetAllProducts(FilterProductsDto filter);
        Task<ProductsResponseDto> GetProductById(Guid productId);
        Task<ProductsResponseDto> AddAsync(ProductsRequestDto productsRequest);
        Task<ProductsResponseDto> UpdateProduct(Guid productId, ProductsRequestDto productsRequest);
        Task<ProductsResponseDto> UpdateProductField(Guid productId, ProductsRequestFieldDto productsRequestField);
        Task<ProductsResponseDto> DeleteProduct(Guid productId); 
    }
}
