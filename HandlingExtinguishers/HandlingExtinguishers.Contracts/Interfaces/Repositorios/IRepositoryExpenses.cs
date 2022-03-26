using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Models;


namespace HandlingExtinguishers.Contracts.Interfaces.Repositorios
{
    public interface IRepositoryExpenses: IBaseRepository<Expenses>
    {
        Task<IEnumerable<Expenses>> ConsultData(FilterExpenses filter); 
    }
}
