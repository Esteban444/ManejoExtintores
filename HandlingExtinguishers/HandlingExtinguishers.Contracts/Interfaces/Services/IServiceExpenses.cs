using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Response;


namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceExpenses
    {
       Task<IEnumerable<ExpenseResponseDto>> GetExpenses(FilterExpenses filter);
       //GastosDTO GetGasto(int id);
       //Task<GastosBase> CrearGasto(GastosBase gasto);
       //Task<GastosBase> ActualizarGasto(int id, GastosBase gasto);
       //Task<GastosDTO> EliminarGasto(int id);

    }
}
