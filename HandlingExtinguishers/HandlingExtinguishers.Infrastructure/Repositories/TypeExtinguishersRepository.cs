using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.Infrastructure.Data;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class TypeExtinguishersRepository: BaseRepository<TypeExtinguisherTable>, IRepositoryTypeExtinguisher
    {
        public TypeExtinguishersRepository(HandlingExtinguishersDbContext context): base(context)
        {

        }
    }
}
