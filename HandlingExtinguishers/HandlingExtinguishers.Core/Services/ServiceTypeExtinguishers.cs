using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request.TypeExtinguisher;
using HandlingExtinguishers.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingExtinguishers.Core.Services
{
    public class ServiceTypeExtinguishers : IServiceTypeExtinguishers
    {
        private readonly IRepositoryTypeExtinguisher _repositoryTypeExtinguisher;
        private readonly IMapper _mapper;
        public ServiceTypeExtinguishers(IRepositoryTypeExtinguisher repositoryType, IMapper mapper)
        {
            _repositoryTypeExtinguisher = repositoryType;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypeExtinguisherResponseDto>> GetAllType()
        {
            var types = await _repositoryTypeExtinguisher.FindBy(x => x.Active).ToListAsync();
            var response = _mapper.Map<IEnumerable<TypeExtinguisherResponseDto>>(types);
            return response;
        }

        public async Task<TypeExtinguisherResponseDto> GetTypeById(Guid typeId)
        {
            var type = await _repositoryTypeExtinguisher.FindBy(x => x.Id == typeId).FirstOrDefaultAsync();
            if (type == null) throw new GlobalException("The type extinguisher record does not exist in the database.", HttpStatusCode.NotFound);
            var response = _mapper.Map<TypeExtinguisherResponseDto>(type);
            return response;
        }
        public async Task<TypeExtinguisherResponseDto> AddAsync(TypeExtinguisherRequestDto typeExtinguisherRequest)
        {
            if (typeExtinguisherRequest.Active != null) typeExtinguisherRequest.Active = true;
            var type = _mapper.Map<TypeExtinguisherTable>(typeExtinguisherRequest);
            await _repositoryTypeExtinguisher.Add(type);
            var response = _mapper.Map<TypeExtinguisherResponseDto>(type);
            return response;
        }
        public async Task<TypeExtinguisherResponseDto> UpdateType(Guid typeId, TypeExtinguisherRequestDto typeExtinguisherRequest)
        {
            if (typeExtinguisherRequest.Active == null) typeExtinguisherRequest.Active = true;
            var type = await _repositoryTypeExtinguisher.FindBy(c => c.Id == typeId).FirstOrDefaultAsync();
            if (type == null) throw new GlobalException("The type extinguisher record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            _mapper.Map(typeExtinguisherRequest, type);
            await _repositoryTypeExtinguisher.Update(type);
            var response = _mapper.Map<TypeExtinguisherResponseDto>(type);
            return response;
        }

        public async Task<TypeExtinguisherResponseDto> UpdateTypeField(Guid typeId, TypeExtinguisherFieldRequestDto typeExtinguisherRequest)
        {
            if (typeExtinguisherRequest.Active == null) typeExtinguisherRequest.Active = true;
            var type = await _repositoryTypeExtinguisher.FindBy(c => c.Id == typeId).FirstOrDefaultAsync(); 
            if (type == null) throw new GlobalException("The type extinguisher record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            var properties = new UpdateMapperProperties<TypeExtinguisherTable, TypeExtinguisherFieldRequestDto>();
            var updateType = await properties.MapperUpdate(type!, typeExtinguisherRequest);
            await _repositoryTypeExtinguisher.Update(updateType);
            var response = _mapper.Map<TypeExtinguisherResponseDto>(updateType);
            return response;
        }
        public async Task<TypeExtinguisherResponseDto> DeleteType(Guid typeId)
        {
            var type = await _repositoryTypeExtinguisher.FindBy(c => c.Id == typeId).FirstOrDefaultAsync();
            if (type == null) throw new GlobalException("The type extinguisher record you are trying to delete does not exist in the database.", HttpStatusCode.NotFound);

            if (type.Active == true)
            {
                type.Active = false;
            }
            else
            {
                type.Active = true;
            }
            await _repositoryTypeExtinguisher.Update(type);
            var typeDeleted = _mapper.Map<TypeExtinguisherResponseDto>(type);
            return typeDeleted;
        }
    }
}
