using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request.Expenses;
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
            var expenses = _repositoryExpenses.GetAll();

            if (!String.IsNullOrEmpty(filter.Description))
            {
                expenses = expenses.Where(x => x.Description!.Contains(filter.Description!));
            }

            if (filter.StartDate <= DateTime.Now &&  filter.EndDate <= DateTime.Now)
            {
                expenses = expenses.Where(x => x.Date <= filter.EndDate);
            }
            var response = await expenses.OrderBy(x => x.Date).ToListAsync();
            var expenseslist = _mapper.Map<IEnumerable<ExpenseResponseDto>>(response);
            return expenseslist;
        }

        public async Task<ExpenseResponseDto> GetExpense(Guid expenseId) 
        {
            var expenseBd =  await _repositoryExpenses.FindBy(c => c.Id ==expenseId).FirstOrDefaultAsync();
            if (expenseBd == null) throw new GlobalException("The expense record does not exist in the database.", HttpStatusCode.NotFound);
            
            return _mapper.Map<ExpenseResponseDto>(expenseBd); 
        }

        public async Task<ExpenseResponseDto> AddAsync(ExpensesRequestDto expenseRequest) 
        {
            if (expenseRequest.Active == null) { expenseRequest.Active = true; }
            var expense = _mapper.Map<ExpenseTable>(expenseRequest);
            await _repositoryExpenses.Add(expense);
            var newexpense = _mapper.Map<ExpenseResponseDto>(expense);
            return newexpense;
        }

        public async Task<ExpenseResponseDto> UpdateExpense(Guid expenseId, ExpensesRequestDto expenseRequestUpdate) 
        {
            if (expenseRequestUpdate.Active == null) { expenseRequestUpdate.Active = true; }
            var expenseBd = await _repositoryExpenses.FindBy(c => c.Id == expenseId).FirstOrDefaultAsync();
            if (expenseBd == null) throw new GlobalException("The expense record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            _mapper.Map(expenseRequestUpdate, expenseBd);

            await _repositoryExpenses.Update(expenseBd);
            var response = _mapper.Map<ExpenseResponseDto>(expenseBd);
            return response;
        }

        public async Task<ExpenseResponseDto> UpdateExpenseField(Guid expenseId, ExpensesRequestUpdateFieldDto expenseRequestUpdateField)
        {
            var expenseBd = await _repositoryExpenses.FindBy(x => x.Id == expenseId).FirstOrDefaultAsync();
            if (expenseBd == null) throw new GlobalException("The expense record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            var properties = new UpdateMapperProperties<ExpenseTable, ExpensesRequestUpdateFieldDto>();
            var updateExpense =  await properties.MapperUpdate(expenseBd!, expenseRequestUpdateField);
            await _repositoryExpenses.Update(updateExpense);
            var response = _mapper.Map<ExpenseResponseDto>(updateExpense);
            return response;
        }

        public async Task<ExpenseResponseDto> DeleteExpenses(Guid expenseId) 
        {
            var expenseBd = await _repositoryExpenses.FindBy(c => c.Id == expenseId).FirstOrDefaultAsync();
            if (expenseBd == null) throw new GlobalException("The expense record you are trying to delete does not exist in the database.", HttpStatusCode.NotFound);
            await _repositoryExpenses.Delete(expenseBd);
            var expenseDeleted = _mapper.Map<ExpenseResponseDto>(expenseBd);
            return expenseDeleted;
            
        }

    }
}
