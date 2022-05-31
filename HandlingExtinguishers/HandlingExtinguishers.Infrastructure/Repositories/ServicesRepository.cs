using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.Infrastructure.Data;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class ServicesRepository: BaseRepository<ServiceTable>, IRepositoryService
    {
        public ServicesRepository(HandlingExtinguishersDbContext context): base(context)
        {

        }
    }
}
