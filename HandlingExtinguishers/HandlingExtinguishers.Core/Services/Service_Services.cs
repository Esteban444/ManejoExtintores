using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request.Services;
using HandlingExtinguishers.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingExtinguishers.Core.Services
{
    public class Service_Services : IService_Services
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        public Service_Services(IRepositoryService repository, IMapper mapper)
        {
            _repositoryService = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceResponseDto>> GetAllServices()
        {
            var services = await _repositoryService.GetAll().ToListAsync();
            var response = _mapper.Map<IEnumerable<ServiceResponseDto>>(services);
            return response;
        }

        public async Task<ServiceResponseDto> GetServiceById(Guid serviceId)
        {
            var service = await _repositoryService.FindBy(x => x.Active && x.Id == serviceId).FirstOrDefaultAsync();
            if (service == null) throw new GlobalException("The service record does not exist in the database.", HttpStatusCode.NotFound);

            return _mapper.Map<ServiceResponseDto>(service);
        }

        public async Task<ServiceResponseDto> AddAsync(ServiceRequestDto serviceRequest)
        {
            if (serviceRequest.Active == null) { serviceRequest.Active = true; }
            var service = _mapper.Map<ServiceTable>(serviceRequest);
            await _repositoryService.Add(service);
            var newService = _mapper.Map<ServiceResponseDto>(service);
            return newService;
        }

        public async Task<ServiceResponseDto> UpdateService(Guid serviceId, ServiceRequestDto ServiceRequest)
        {
            if (ServiceRequest.Active == null) { ServiceRequest.Active = true; }
            var service = await _repositoryService.FindBy(x => x.Id == serviceId).FirstOrDefaultAsync();
            if (service == null) throw new GlobalException("The service record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            _mapper.Map(ServiceRequest, service);
            await _repositoryService.Update(service);
            var response = _mapper.Map<ServiceResponseDto>(service);
            return response;
        }

        public async Task<ServiceResponseDto> UpdateServiceField(Guid serviceId, ServicesRequestFieldDto serviceRequestField)
        {
            var service = await _repositoryService.FindBy(x => x.Id == serviceId).FirstOrDefaultAsync();
            if (service == null) throw new GlobalException("The service record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            var properties = new UpdateMapperProperties<ServiceTable, ServicesRequestFieldDto>();
            var updateService = await properties.MapperUpdate(service!, serviceRequestField);
            await _repositoryService.Update(updateService);
            var response = _mapper.Map<ServiceResponseDto>(updateService);
            return response;
        }

        public async Task<ServiceResponseDto> DeletedService(Guid serviceId)
        {

            var service = await _repositoryService.FindBy(c => c.Id == serviceId).FirstOrDefaultAsync();
            if (service == null) throw new GlobalException("The service record you are trying to delete does not exist in the database.", HttpStatusCode.NotFound);

            if (service.Active == true)
            {
                service.Active = false;
            }
            else
            {
                service.Active = true;
            }
            await _repositoryService.Update(service);
            var serviceDeleted = _mapper.Map<ServiceResponseDto>(service);
            return serviceDeleted;
        }
    }
}
