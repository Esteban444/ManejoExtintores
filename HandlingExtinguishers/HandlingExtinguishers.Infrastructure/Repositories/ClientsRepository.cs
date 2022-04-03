using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;


namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class ClientsRepository : BaseRepository<Client>, IRepositoryClients
    {
        public ClientsRepository(HandlingExtinguishersDbContext context) : base(context) 
        {

        }   
    }
}
