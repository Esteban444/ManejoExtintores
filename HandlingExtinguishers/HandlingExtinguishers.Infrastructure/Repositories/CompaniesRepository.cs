using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;


namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class CompaniesRepository : BaseRepository<Companies>, IRepositoryCompanies
    {
        //public HandlingExtinguishersDbContext handlingExtinguishersDbContext { get; set; }
        public CompaniesRepository(HandlingExtinguishersDbContext context) : base(context)
        {
            
        }
    }
}
