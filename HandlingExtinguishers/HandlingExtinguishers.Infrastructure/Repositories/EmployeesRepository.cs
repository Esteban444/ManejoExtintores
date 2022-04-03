using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;


namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class EmployeesRepository : BaseRepository<Employee>, IRepositoryEmployees
    {
        public EmployeesRepository(HandlingExtinguishersDbContext context): base(context)    
        {

        }
    }
}
