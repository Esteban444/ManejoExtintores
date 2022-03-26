using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;


namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceExpenses
    {
       Task<IEnumerable<ExpenseResponseDto>> GetExpenses(FilterExpenses filter);
       Task<ExpenseResponseDto> GetExpense(Guid expenseId); 
       Task<ExpenseResponseDto> AddAsync(ExpensesRequestDto expenseRequest); 
       Task<ExpenseResponseDto> UpdateExpense(Guid expenseId, ExpensesRequestDto expenseRequest);  
       Task<ExpenseResponseDto> UpdateExpenseField(Guid expenseId, ExpensesRequestDto expenseRequest);    
       Task<ExpenseResponseDto> DeleteExpenses(Guid expenseId);  

    }
}
