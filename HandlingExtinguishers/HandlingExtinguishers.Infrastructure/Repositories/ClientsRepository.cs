using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.Infrastructure.Data;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class ClientsRepository : BaseRepository<ClientTable>, IRepositoryClients
    {
        public ClientsRepository(HandlingExtinguishersDbContext context) : base(context) 
        {

        }   
    }
}
