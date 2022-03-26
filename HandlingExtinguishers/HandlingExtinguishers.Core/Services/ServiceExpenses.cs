using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
            if (expensebd == null) throw new GlobalException("The expense record does not exist in the database.", HttpStatusCode.NotFound);
            
            return _mapper.Map<ExpenseResponseDto>(expensebd); 
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
            if (expensebd == null) throw new GlobalException("The expense record you are trying to update does not exist in the database.", HttpStatusCode.BadRequest);

            _mapper.Map(expenseRequest, expensebd);

            await _repositoryExpenses.Update(expensebd);
            var response = _mapper.Map<ExpenseResponseDto>(expensebd);
            return response;
        }

        public async Task<ExpenseResponseDto> UpdateExpenseField(Guid expenseId, ExpensesRequestDto expenseRequest)
        {
            var expensebd = await _repositoryExpenses.FindBy(x => x.IdExpense == expenseId).FirstOrDefaultAsync();
            if (expensebd == null) throw new GlobalException("The expense record you are trying to update does not exist in the database.", HttpStatusCode.BadRequest);

            var properties = new UpdateMapperProperties<Expenses, ExpensesRequestDto>();
            var updateExpense =  await properties.MapperUpdate(expensebd!, expenseRequest);
            await _repositoryExpenses.Update(updateExpense);
            var response = _mapper.Map<ExpenseResponseDto>(updateExpense);
            return response;
        }

        public async Task<ExpenseResponseDto> DeleteExpenses(Guid expenseId) 
        {
            var expensebd = await _repositoryExpenses.FindBy(c => c.IdExpense == expenseId).FirstOrDefaultAsync();
            if (expensebd == null) throw new GlobalException("The expense record you are trying to delete does not exist in the database.", HttpStatusCode.NotFound);
            await _repositoryExpenses.Delete(expensebd);
            var expenseDeleted = _mapper.Map<ExpenseResponseDto>(expensebd);
            return expenseDeleted;
            
        }

    }
}
