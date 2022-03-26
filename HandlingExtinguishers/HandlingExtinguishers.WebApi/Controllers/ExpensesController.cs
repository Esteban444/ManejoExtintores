using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IServiceExpenses _serviceExpenses;
        

        public ExpensesController(IServiceExpenses serviceExpenses ) 
        {
            _serviceExpenses = serviceExpenses;
            
        }

        [HttpGet]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        public async Task<IActionResult> ConsultExpenses([FromQuery] FilterExpenses filter) 
        {
            var expenses = await _serviceExpenses.GetExpenses(filter);
            return Ok(expenses);
        }

        [HttpGet("{expenseId}")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        public async Task<IActionResult> ConsultExpenseById(Guid expenseId) 
        {
            var expense = await _serviceExpenses.GetExpense(expenseId);
            return Ok(expense);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        public async Task<IActionResult> AddAsync( ExpensesRequestDto expenseRequest) 
        {
            var response = await _serviceExpenses.AddAsync(expenseRequest);
            return Ok(response); 
        }

        [HttpPut("{expenseId}")]
        public async Task<IActionResult> UpdateExpenses(Guid expenseId, ExpensesRequestDto expenseRequest) 
        {
           var result = await _serviceExpenses.UpdateExpense(expenseId,expenseRequest); 
           return Ok(result);
            
        }

        [HttpPatch("{expenseId}")]
        public async Task<IActionResult> UpdateExpensesField(Guid expenseId, ExpensesRequestDto expenseRequest) 
        {
            var result = await _serviceExpenses.UpdateExpenseField(expenseId, expenseRequest);
            return Ok(result);

        }

        [HttpDelete("{expenseId}")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        public async Task<IActionResult> Delete(Guid expenseId)
        {
            var result = await _serviceExpenses.DeleteExpenses(expenseId);
            return Ok(result);
        }
    }

    internal class HttpPachAttribute : Attribute
    {
    }
}
