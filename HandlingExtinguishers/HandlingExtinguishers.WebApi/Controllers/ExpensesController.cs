using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Request.Expenses;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    /// <summary>
    /// With this Api you will be able to manage expenses.
    /// </summary>
    [Route("api/expenses")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ExpensesController : ControllerBase
    {
        private readonly IServiceExpenses _serviceExpenses;

        /// <summary>
        /// Methodo constructor.
        /// </summary>
        /// <param name="serviceExpenses"></param>
        public ExpensesController(IServiceExpenses serviceExpenses ) 
        {
            _serviceExpenses = serviceExpenses;
            
        }

        /// <summary>
        /// This endpoint returns all expenses.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("get-all-expenses")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        [ProducesResponseType(typeof(ExpenseResponseDto), 400)] 
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultExpenses([FromQuery] FilterExpenses filter) 
        {
            var expenses = await _serviceExpenses.GetExpenses(filter);
            return Ok(expenses);
        }

        /// <summary>
        /// This endpoint returns a expense by Id.
        /// </summary>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        [HttpGet("get-expense-by/{expenseId}")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        [ProducesResponseType(typeof(ExpenseResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultExpenseById(Guid expenseId) 
        {
            var expense = await _serviceExpenses.GetExpense(expenseId);
            return Ok(expense);
        }

        /// <summary>
        /// This endpoint add a expense.
        /// </summary>
        /// <param name="expenseRequest"></param>
        /// <returns></returns>
        [HttpPost("expense")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        [ProducesResponseType(typeof(ExpenseResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync( ExpensesRequestDto expenseRequest) 
        {
            var response = await _serviceExpenses.AddAsync(expenseRequest);
            return Ok(response); 
        }

        /// <summary>
        /// This endpoint update a expense by Id.
        /// </summary>
        /// <param name="expenseId"></param>
        /// <param name="expenseRequest"></param>
        /// <returns></returns>
        [HttpPut("update-expense/{expenseId}")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        [ProducesResponseType(typeof(ExpenseResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateExpenses(Guid expenseId, ExpensesRequestDto expenseRequest) 
        {
           var result = await _serviceExpenses.UpdateExpense(expenseId,expenseRequest); 
           return Ok(result);
            
        }

        /// <summary>
        /// This endpoint update a expense by Id.
        /// </summary>
        /// <param name="expenseId"></param>
        /// <param name="expenseRequest"></param>
        /// <returns></returns>
        [HttpPatch("update-fields-expense/{expenseId}")]
        [ProducesResponseType(typeof(ExpenseResponseDto), 200)]
        [ProducesResponseType(typeof(ExpenseResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateExpensesField(Guid expenseId, ExpensesRequestUpdateFieldDto expenseRequest) 
        {
            var result = await _serviceExpenses.UpdateExpenseField(expenseId, expenseRequest);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint delete a expense by Id.
        /// </summary>
        /// <param name="expenseId"></param>
        /// <returns></returns>
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
