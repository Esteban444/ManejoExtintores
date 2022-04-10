using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.Infrastructure.Data;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class ExpensesRepository: BaseRepository<ExpenseTable>,IRepositoryExpenses
    {
        public ExpensesRepository(HandlingExtinguishersDbContext context) : base(context)
        {
        }
    }
}
