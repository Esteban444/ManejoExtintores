using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.Infrastructure.Data;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class CompaniesRepository : BaseRepository<CompanyTable>, IRepositoryCompanies
    {
        public CompaniesRepository(HandlingExtinguishersDbContext context) : base(context)
        {
            
        }
    }
}
