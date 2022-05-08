using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request.Products;
using HandlingExtinguishers.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingExtinguishers.Core.Services
{
    public class ServiceProducts : IProductsService
    {
        private readonly IRepositoryProducts _repository;
        private readonly IMapper _mapper;
        public ServiceProducts(IRepositoryProducts products, IMapper mapper)
        {
            _repository = products;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductsResponseDto>> GetAllProducts(FilterProductsDto filter)
        {
            var products = _repository.FindBy(x => x.Active);

            if (!String.IsNullOrEmpty(filter.TypeProduct))
            {
                products = products.Where(x => x.TypeProduct!.Contains(filter.TypeProduct!));
            }
            
            var result = await products.OrderBy(x => x.TypeProduct).Include(x => x.TypeExtinguisher).Include(z => z.WeightExtinguisher).ToListAsync();
             var response = _mapper.Map<IEnumerable<ProductsResponseDto>>(result);  
            return response;
        }

        public async Task<ProductsResponseDto> GetProductById(Guid productId)
        {
            var product = await _repository.FindBy(x => x.Active && x.Id == productId).FirstOrDefaultAsync();
            if (product == null) throw new GlobalException("The product record does not exist in the database.", HttpStatusCode.NotFound);
            var response = _mapper.Map<ProductsResponseDto>(product);
            return response;
        }

        public async Task<ProductsResponseDto> AddAsync(ProductsRequestDto productsRequest)
        {
            if (productsRequest.Active != null) productsRequest.Active = true;
            var product = _mapper.Map<ProductTable>(productsRequest);
            await _repository.Add(product);
            var response = _mapper.Map<ProductsResponseDto>(product);
            return response;
        }
        public async Task<ProductsResponseDto> UpdateProduct(Guid productId, ProductsRequestDto productsRequest)
        {
            if (productsRequest.Active != null) productsRequest.Active = true;
            var product = await _repository.FindBy(x => x.Active && x.Id == productId).FirstOrDefaultAsync();
            if (product == null) throw new GlobalException("The product record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            _mapper.Map(productsRequest, product);

            await _repository.Update(product);
            var response = _mapper.Map<ProductsResponseDto>(product);
            return response;
        }

        public async Task<ProductsResponseDto> UpdateProductField(Guid productId, ProductsRequestFieldDto productsRequestField)
        {
            var product = await _repository.FindBy(c => c.Active && c.Id == productId).FirstOrDefaultAsync();
            if (product == null) throw new GlobalException("The product record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            var properties = new UpdateMapperProperties<ProductTable, ProductsRequestFieldDto>();
            var updateProduct = await properties.MapperUpdate(product!, productsRequestField);
            await _repository.Update(updateProduct);
            var response = _mapper.Map<ProductsResponseDto>(updateProduct);
            return response;
        }

        public async Task<ProductsResponseDto> DeleteProduct(Guid productId)
        {
            var product = await _repository.FindBy(c => c.Id == productId).FirstOrDefaultAsync();
            if (product == null) throw new GlobalException("The product record you are trying to delete does not exist in the database.", HttpStatusCode.NotFound);

            if (product.Active == true)
            {
                product.Active = false;
            }
            else
            {
                product.Active = true;
            }
            await _repository.Update(product);
            var response = _mapper.Map<ProductsResponseDto>(product);
            return response;
        }

    }
}
