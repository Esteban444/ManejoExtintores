using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.Infrastructure.Data;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class WeightExtinguisherRepository: BaseRepository<WeightExtinguisherTable>, IRepositoryWeightExtinguisher
    {
        public WeightExtinguisherRepository(HandlingExtinguishersDbContext context): base(context)
        {

        }
    }
}
