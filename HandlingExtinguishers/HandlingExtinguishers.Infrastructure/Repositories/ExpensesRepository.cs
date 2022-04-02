using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;


namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class ExpensesRepository: BaseRepository<Expenses>,IRepositoryExpenses
    {
        public ExpensesRepository(HandlingExtinguishersDbContext context) : base(context)
        {
        }
    }
}
