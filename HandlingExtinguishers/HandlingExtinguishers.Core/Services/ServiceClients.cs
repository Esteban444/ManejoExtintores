using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request.Clients;
using HandlingExtinguishers.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingExtinguishers.Core.Services
{
    public class ServiceClients : IServiceClients
    {
        private readonly IRepositoryClients _repositoryClients;
        private readonly IMapper _mapper;
        public ServiceClients(IRepositoryClients repositoryClients, IMapper mapper)
        {
            _repositoryClients = repositoryClients;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientResponseDto>> GetAllClients(ClientFilterDto filter)
        {
            var clients = _repositoryClients.FindBy(x => x.Active);

            if (!String.IsNullOrEmpty(filter.FirstName) || !String.IsNullOrEmpty(filter.LastName) 
                || !String.IsNullOrEmpty(filter.Nit!) || !String.IsNullOrEmpty(filter.Gender))
            {
                clients = clients.Where(x => x.FirstName!.Contains(filter.FirstName!) || x.LastName!.Contains(filter.LastName!) ||
                x.Nit!.Contains(filter.Nit!) || x.Gender!.Contains(filter.Gender!));
            }

            if (filter.Nit != null)
            {
                clients = clients.Where(x => x.Nit == filter.Nit);
            }
            var response = await clients.OrderBy(x => x.FirstName).ToListAsync();
            var clientslist = _mapper.Map<IEnumerable<ClientResponseDto>>(response);
            return clientslist;
        }

        public async Task<ClientResponseDto> GetClientById(Guid clientId)
        {
            var clientBd = await _repositoryClients.FindBy(c => c.Id == clientId).FirstOrDefaultAsync();
            if (clientBd == null) throw new GlobalException("The client record does not exist in the database.", HttpStatusCode.NotFound);

            return _mapper.Map<ClientResponseDto>(clientBd);
        }
        public async Task<ClientResponseDto> AddAsync(ClientRequestDto clientRequest)
        {
            if (clientRequest.Active == null) { clientRequest.Active = true; }
            var client = _mapper.Map<ClientTable>(clientRequest);
            await _repositoryClients.Add(client);
            var newClient = _mapper.Map<ClientResponseDto>(client); 
            return newClient;
        }

        public async Task<ClientResponseDto> UpdateClient(Guid clientId, ClientRequestDto clientRequestUpdate)
        {
            if (clientRequestUpdate.Active == null) { clientRequestUpdate.Active = true; }
            var clientBd = await _repositoryClients.FindBy(c => c.Id == clientId).FirstOrDefaultAsync();
            if (clientBd == null) throw new GlobalException("The client record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            _mapper.Map(clientRequestUpdate, clientBd);

            await _repositoryClients.Update(clientBd);
            var response = _mapper.Map<ClientResponseDto>(clientBd);
            return response;
        }

        public async Task<ClientResponseDto> UpdateClientField(Guid clientId, ClientRequestUpdateFieldDto clientRequestField)
        {
            var clientBd = await _repositoryClients.FindBy(x => x.Id == clientId).FirstOrDefaultAsync();
            if (clientBd == null) throw new GlobalException("The client record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            var properties = new UpdateMapperProperties<ClientTable, ClientRequestUpdateFieldDto>();
            var updateClient = await properties.MapperUpdate(clientBd!, clientRequestField);
            await _repositoryClients.Update(updateClient);
            var response = _mapper.Map<ClientResponseDto>(updateClient);
            return response;
        }
        public async Task<ClientResponseDto> DeleteClient(Guid clientId)
        {
            var clientBd = await _repositoryClients.FindBy(c => c.Id == clientId).FirstOrDefaultAsync();
            if (clientBd == null) throw new GlobalException("The client record you are trying to delete does not exist in the database.", HttpStatusCode.NotFound);

            if(clientBd.Active == true)
            {
                clientBd.Active = false;
            }
            else
            {
                clientBd.Active = true;
            }
            await _repositoryClients.Update(clientBd);
            var clientDeleted = _mapper.Map<ClientResponseDto>(clientBd);
            return clientDeleted;
        }
    }
}
