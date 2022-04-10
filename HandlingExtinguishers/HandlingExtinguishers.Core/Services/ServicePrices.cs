using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request.Prices;
using HandlingExtinguishers.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingExtinguishers.Core.Services 
{
    public class ServicePrices : IServicePrices
    {
        private readonly IRepositoryPrice _repositoryPrice;
        private readonly IMapper _mapper;
        public ServicePrices(IRepositoryPrice repositoryPrice, IMapper mapper)
        {
            _repositoryPrice = repositoryPrice;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PriceResponseDto>> GetAllPrices()
        {
            var prices =  await _repositoryPrice.FindBy(x => x.Active).ToListAsync();
          
            var pricelist = _mapper.Map<IEnumerable<PriceResponseDto>>(prices);
            return pricelist;
        }

        public async Task<PriceResponseDto> GetPriceById(Guid priceId)
        {
            var priceBd = await _repositoryPrice.FindBy(c => c.Id == priceId).FirstOrDefaultAsync();
            if (priceBd == null) throw new GlobalException("The price record does not exist in the database.", HttpStatusCode.NotFound);

            var response = _mapper.Map<PriceResponseDto>(priceBd);
            return response;
        }

        public async Task<PriceResponseDto> AddAsync(PriceRequestDto priceRequest)
        {
            if (priceRequest.Active == null) priceRequest.Active = true;
            var  price = _mapper.Map<PriceTable>(priceRequest);
            var iva = price.Price * price.Iva / 100;
            price.Iva = iva;
            price.EndPrice = price.Price + iva;
            await _repositoryPrice.Add(price);
            var response = _mapper.Map<PriceResponseDto>(price);
            return response;
        }

        public async Task<PriceResponseDto> UpdatePrice(Guid priceId, PriceRequestDto priceRequest)
        {
            if (priceRequest.Active == null) priceRequest.Active = true;
            var priceBd = await _repositoryPrice.FindBy(c => c.Id == priceId).FirstOrDefaultAsync();
            if (priceBd == null) throw new GlobalException("The price record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            if(priceBd.Price != priceRequest.Price)
            {
                var iva = priceRequest.Price * priceRequest.Iva / 100;
                priceRequest.Iva = iva;
                priceBd.EndPrice = priceRequest.Price + iva;
            }

            _mapper.Map(priceRequest, priceBd);
            await _repositoryPrice.Update(priceBd);
            var response = _mapper.Map<PriceResponseDto>(priceBd);
            return response;
        }

        public async Task<PriceResponseDto> UpdatePriceField(Guid priceId, PriceRequestUpdateFieldDto priceRequestUpdateField)
        {
            var priceBd = await _repositoryPrice.FindBy(x => x.Id == priceId).FirstOrDefaultAsync();
            if (priceBd == null) throw new GlobalException("The price record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            if(priceRequestUpdateField.Price == null) priceRequestUpdateField.Price = priceBd.Price;

            if (priceBd.Price != priceRequestUpdateField.Price)
            {
                var iva = priceRequestUpdateField.Price * priceRequestUpdateField.Iva / 100;
                priceRequestUpdateField.Iva = iva; 
                priceBd.EndPrice = priceRequestUpdateField.Price + iva;
            }

            var properties = new UpdateMapperProperties<PriceTable, PriceRequestUpdateFieldDto>();
            var updatePrice = await properties.MapperUpdate(priceBd!, priceRequestUpdateField);
            await _repositoryPrice.Update(updatePrice);
            var response = _mapper.Map<PriceResponseDto>(updatePrice); 
            return response;
        }

        public async Task<PriceResponseDto> DeletePrice(Guid priceId)
        {
            var priceBd = await _repositoryPrice.FindBy(c => c.Id == priceId).FirstOrDefaultAsync();
            if (priceBd == null) throw new GlobalException("The client record you are trying to delete does not exist in the database.", HttpStatusCode.NotFound);

            if (priceBd.Active == true)
            {
                priceBd.Active = false;
            }
            else
            {
                priceBd.Active = true;
            }
            await _repositoryPrice.Update(priceBd);
            var priceDeleted = _mapper.Map<PriceResponseDto>(priceBd); 
            return priceDeleted;
        }
    }
}
