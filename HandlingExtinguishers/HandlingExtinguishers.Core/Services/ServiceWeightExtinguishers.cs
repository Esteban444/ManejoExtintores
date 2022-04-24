using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request.WeightExtinguisher;
using HandlingExtinguishers.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingExtinguishers.Core.Services
{
    public class ServiceWeightExtinguishers : IServiceWeightExtinguishers
    {
        private readonly IRepositoryWeightExtinguisher _repositoryWeightExtinguisher;
        private readonly IMapper _mapper;
        public ServiceWeightExtinguishers(IRepositoryWeightExtinguisher repositoryWeight, IMapper mapper)
        {
            _repositoryWeightExtinguisher = repositoryWeight;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WeightExtinguisherResponseDto>> GetAllWeight()
        {
            var weights = await _repositoryWeightExtinguisher.FindBy(x => x.Active).ToListAsync();
            var response = _mapper.Map<IEnumerable<WeightExtinguisherResponseDto>>(weights);
            return response;
        }

        public async Task<WeightExtinguisherResponseDto> GetWeightById(Guid weightId)
        {
            var weight = await _repositoryWeightExtinguisher.FindBy(x => x.Active && x.Id == weightId).FirstOrDefaultAsync();
            if (weight == null) throw new GlobalException("The weight extinguisher record does not exist in the database.", HttpStatusCode.NotFound);
            var response = _mapper.Map<WeightExtinguisherResponseDto>(weight);
            return response;
        }

        public async Task<WeightExtinguisherResponseDto> AddAsync(WeightExtinguisherRequestDto weightExtinguisherRequest)
        {
            if (weightExtinguisherRequest.Active != null) weightExtinguisherRequest.Active = true;
            var weight = _mapper.Map<WeightExtinguisherTable>(weightExtinguisherRequest);
            await _repositoryWeightExtinguisher.Add(weight);
            var response = _mapper.Map<WeightExtinguisherResponseDto>(weight);
            return response;
        }

        public async Task<WeightExtinguisherResponseDto> UpdateWeight(Guid weightId, WeightExtinguisherRequestDto weightExtinguisherRequest)
        {
            if (weightExtinguisherRequest.Active == null) weightExtinguisherRequest.Active = true;
            var weight = await _repositoryWeightExtinguisher.FindBy(c => c.Active && c.Id == weightId).FirstOrDefaultAsync();
            if (weight == null) throw new GlobalException("The weight extinguisher record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            _mapper.Map(weightExtinguisherRequest, weight);
            await _repositoryWeightExtinguisher.Update(weight);
            var response = _mapper.Map<WeightExtinguisherResponseDto>(weight);
            return response;
        }

        public async Task<WeightExtinguisherResponseDto> UpdateWeightField(Guid weightId, WeightExtinguisherFieldRequestDto weightExtinguisherFieldRequest)
        {
            var weight = await _repositoryWeightExtinguisher.FindBy(c => c.Active && c.Id == weightId).FirstOrDefaultAsync();
            if (weight == null) throw new GlobalException("The weight extinguisher record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            var properties = new UpdateMapperProperties<WeightExtinguisherTable, WeightExtinguisherFieldRequestDto>();
            var updateWeight = await properties.MapperUpdate(weight!, weightExtinguisherFieldRequest);
            await _repositoryWeightExtinguisher.Update(updateWeight);
            var response = _mapper.Map<WeightExtinguisherResponseDto>(updateWeight);
            return response;
        }
        public async Task<WeightExtinguisherResponseDto> DeleteWeight(Guid weightId)
        {
            var weight = await _repositoryWeightExtinguisher.FindBy(c => c.Id == weightId).FirstOrDefaultAsync();
            if (weight == null) throw new GlobalException("The weight extinguisher record you are trying to delete does not exist in the database.", HttpStatusCode.NotFound);

            if (weight.Active == true)
            {
                weight.Active = false;
            }
            else
            {
                weight.Active = true;
            }
            await _repositoryWeightExtinguisher.Update(weight);
            var typeDeleted = _mapper.Map<WeightExtinguisherResponseDto>(weight);
            return typeDeleted;
        }
    }
}
