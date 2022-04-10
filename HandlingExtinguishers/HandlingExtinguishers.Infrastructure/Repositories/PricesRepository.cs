using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.Infrastructure.Data;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class PricesRepository: BaseRepository<PriceTable>, IRepositoryPrice
    {
        public PricesRepository(HandlingExtinguishersDbContext context): base(context)
        {

        }
    }
}
