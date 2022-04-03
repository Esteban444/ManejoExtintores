using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;


namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IRepositoryEmployees
    {
        public EmployeeRepository(HandlingExtinguishersDbContext context): base(context)    
        {

        }
    }
}
