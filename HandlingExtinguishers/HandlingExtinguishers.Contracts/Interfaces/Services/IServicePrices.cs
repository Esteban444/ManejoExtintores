using HandlingExtinguishers.DTO.Request.Prices;
using HandlingExtinguishers.DTO.Response;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServicePrices
    {
        Task<IEnumerable<PriceResponseDto>> GetAllPrices();
        Task<PriceResponseDto> GetPriceById(Guid priceId);
        Task<PriceResponseDto> AddAsync(PriceRequestDto priceRequest);
        Task<PriceResponseDto> UpdatePrice(Guid priceId, PriceRequestDto priceRequest);
        Task<PriceResponseDto> UpdatePriceField(Guid priceId, PriceRequestUpdateFieldDto priceRequestUpdateField);
        Task<PriceResponseDto> DeletePrice(Guid priceId);
    }
}
