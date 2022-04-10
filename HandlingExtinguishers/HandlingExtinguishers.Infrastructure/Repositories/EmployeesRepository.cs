using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.Infrastructure.Data;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class EmployeesRepository : BaseRepository<EmployeeTable>, IRepositoryEmployees
    {
        public EmployeesRepository(HandlingExtinguishersDbContext context): base(context)    
        {

        }
    }
}
