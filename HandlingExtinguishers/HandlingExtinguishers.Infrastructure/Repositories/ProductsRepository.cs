using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.Infrastructure.Data;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class ProductsRepository: BaseRepository<ProductTable>, IRepositoryProducts
    {
        public ProductsRepository(HandlingExtinguishersDbContext context): base(context)
        {

        }
    }
}
