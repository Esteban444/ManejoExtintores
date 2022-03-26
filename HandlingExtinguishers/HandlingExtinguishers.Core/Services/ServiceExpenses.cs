using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;
using Microsoft.EntityFrameworkCore;


namespace HandlingExtinguishers.Core.Services
{
    public class ServiceExpenses: IServiceExpenses 
    {
        private readonly IRepositoryExpenses _repositoryExpenses; 
        private readonly IMapper _mapper;

        public ServiceExpenses(IRepositoryExpenses repositoryExpenses, IMapper mapper) 
        {
            _repositoryExpenses = repositoryExpenses;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ExpenseResponseDto>> GetExpenses(FilterExpenses filter) 
        {
            var expenses = await _repositoryExpenses.ConsultData(filter);  
            var expensesdt = _mapper.Map<IEnumerable<ExpenseResponseDto>>(expenses);
            return expensesdt;
        }

        public async Task<ExpenseResponseDto> GetExpense(Guid expenseId) 
        {
            var expensebd =  await _repositoryExpenses.FindBy(c => c.IdExpense ==expenseId).FirstOrDefaultAsync();
            if (expensebd != null)
            {
                return _mapper.Map<ExpenseResponseDto>(expensebd);
            }
            else
            {
                throw new Exception("El registro de gasto no existe en la base de datos" );
            }
        }

        public async Task<ExpenseResponseDto> AddAsync(ExpensesRequestDto expenseRequest) 
        {
            var expense = _mapper.Map<Expenses>(expenseRequest);
            await _repositoryExpenses.Add(expense);
            var newexpense = _mapper.Map<ExpenseResponseDto>(expense);
            return newexpense;
        }

        public async Task<ExpenseResponseDto> UpdateExpense(Guid expenseId, ExpensesRequestDto expenseRequest) 
        {
            var expensebd = await _repositoryExpenses.FindBy(c => c.IdExpense == expenseId).FirstOrDefaultAsync(); 
            if (expensebd != null)
            {
                _mapper.Map(expenseRequest, expensebd);

                await _repositoryExpenses.Update(expensebd);
                var response = _mapper.Map<ExpenseResponseDto>(expensebd);
                return response;
            }
            else
            {
                throw new Exception("El registro de gasto que desea actualizar no existe en la base de datos" );
            }
        }

        public async Task<ExpenseResponseDto> UpdateExpenseField(Guid expenseId, ExpensesRequestDto expenseRequest)
        {
            var expense = await _repositoryExpenses.FindBy(x => x.IdExpense == expenseId).FirstOrDefaultAsync(); 

            var properties = new UpdateMapperProperties<Expenses, ExpensesRequestDto>();
            var updateExpense =  await properties.MapperUpdate(expense!, expenseRequest);
            await _repositoryExpenses.Update(updateExpense);
            var response = _mapper.Map<ExpenseResponseDto>(updateExpense);
            return response;
        }

        public async Task<ExpenseResponseDto> DeleteExpenses(Guid expenseId) 
        {
            var expensebd = await _repositoryExpenses.FindBy(c => c.IdExpense == expenseId).FirstOrDefaultAsync();
            if (expensebd != null)
            {
                await _repositoryExpenses.Delete(expensebd);
                var expenseDeleted = _mapper.Map<ExpenseResponseDto>(expensebd);
                return expenseDeleted;
            }
            else
            {
                throw new Exception("El gasto no existe en la base de datos" );
            }
        }

    }
}
