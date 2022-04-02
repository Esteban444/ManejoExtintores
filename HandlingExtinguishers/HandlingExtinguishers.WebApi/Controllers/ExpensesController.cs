using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("api/expenses")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IServiceExpenses _serviceExpenses;
        

        public ExpensesController(IServiceExpenses serviceExpenses ) 
        {
            _serviceExpenses = serviceExpenses;
            
        }

        [HttpGet("get-all-expenses")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        [ProducesResponseType(typeof(ExpenseResponseDto), 400)] 
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultExpenses([FromQuery] FilterExpenses filter) 
        {
            var expenses = await _serviceExpenses.GetExpenses(filter);
            return Ok(expenses);
        }

        [HttpGet("get-expense-by/{expenseId}")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        [ProducesResponseType(typeof(ExpenseResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultExpenseById(Guid expenseId) 
        {
            var expense = await _serviceExpenses.GetExpense(expenseId);
            return Ok(expense);
        }

        [HttpPost("expense")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        [ProducesResponseType(typeof(ExpenseResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync( ExpensesRequestDto expenseRequest) 
        {
            var response = await _serviceExpenses.AddAsync(expenseRequest);
            return Ok(response); 
        }

        [HttpPut("update-expense/{expenseId}")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        [ProducesResponseType(typeof(ExpenseResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateExpenses(Guid expenseId, ExpensesRequestDto expenseRequest) 
        {
           var result = await _serviceExpenses.UpdateExpense(expenseId,expenseRequest); 
           return Ok(result);
            
        }

        [HttpPatch("update-fields-expense/{expenseId}")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        [ProducesResponseType(typeof(ExpenseResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateExpensesField(Guid expenseId, ExpensesRequestUpdateFieldDto expenseRequest) 
        {
            var result = await _serviceExpenses.UpdateExpenseField(expenseId, expenseRequest);
            return Ok(result);

        }

        [HttpDelete("delete-expense/{expenseId}")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        [ProducesResponseType(typeof(ExpenseResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> Delete(Guid expenseId)
        {
            var result = await _serviceExpenses.DeleteExpenses(expenseId);
            return Ok(result);
        }
    }
}
