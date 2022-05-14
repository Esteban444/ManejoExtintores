using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.Infrastructure.Data;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class InventoryRepository: BaseRepository<InventoryTable>, IRepositoryInventory
    {
        public InventoryRepository(HandlingExtinguishersDbContext context ): base(context)
        {

        }
    }
}
