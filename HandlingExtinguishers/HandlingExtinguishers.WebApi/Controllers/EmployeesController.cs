using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceEmployees _serviceEmployee;


        public EmployeesController(IServiceEmployees serviceEmployees)
        {
            _serviceEmployee = serviceEmployees;

        }

        [HttpGet("get-all-employees")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(EmployeeResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultEmployees([FromQuery] EmployeeFilter filter)
        {
            var employees = await _serviceEmployee.GetAllEmployees(filter);
            return Ok(employees);
        }

        [HttpGet("get-employee-by/{employeeId}")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(EmployeeResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultEmployeeById(Guid employeeId)
        {
            var employee = await _serviceEmployee.GetEmployeeBy(employeeId);
            return Ok(employee);
        }

        [HttpPost("employee")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(EmployeeResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(EmployeeRequestDto employeeRequest)
        {
            var response = await _serviceEmployee.AddAsync(employeeRequest);
            return Ok(response);
        }

        [HttpPut("update-employee/{employeeId}")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(EmployeeResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId, EmployeeRequestDto employeeRequest)
        {
            var result = await _serviceEmployee.UpdateEmployee(employeeId, employeeRequest);
            return Ok(result);

        }

        [HttpPatch("update-fields-employee/{employeeId}")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(EmployeeResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateEmployeeField(Guid employeeId, EmployeeRequestUpdateFieldDto employeeRequest) 
        {
            var result = await _serviceEmployee.UpdateEmployeeField(employeeId, employeeRequest);
            return Ok(result);

        }

        [HttpDelete("delete-employee/{employeeId}")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(EmployeeResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId) 
        {
            var result = await _serviceEmployee.DeleteEmployee(employeeId);
            return Ok(result);
        }
    }
}
