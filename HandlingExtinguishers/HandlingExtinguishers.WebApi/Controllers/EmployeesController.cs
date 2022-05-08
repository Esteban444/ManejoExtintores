using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Request.Employees;
using HandlingExtinguishers.DTO.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    /// <summary>
    /// With this Api you will be able to manage employees.
    /// </summary>
    [Route("api/employees")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceEmployees _serviceEmployee;

        /// <summary>
        /// Methodo constructor.
        /// </summary>
        /// <param name="serviceEmployees"></param>
        public EmployeesController(IServiceEmployees serviceEmployees)
        {
            _serviceEmployee = serviceEmployees;

        }

        /// <summary>
        /// This endpoint returns all employees.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("get-all-employees")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(EmployeeResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultEmployees([FromQuery] EmployeeFilterDto filter)
        {
            var employees = await _serviceEmployee.GetAllEmployees(filter);
            return Ok(employees);
        }

        /// <summary>
        /// This endpoint returns a employee by Id.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("get-employee-by/{employeeId}")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(EmployeeResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> ConsultEmployeeById(Guid employeeId)
        {
            var employee = await _serviceEmployee.GetEmployeeBy(employeeId);
            return Ok(employee);
        }

        /// <summary>
        /// This endpoint add a employee.
        /// </summary>
        /// <param name="employeeRequest"></param>
        /// <returns></returns>
        [HttpPost("employee")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(EmployeeResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(EmployeeRequestDto employeeRequest)
        {
            var response = await _serviceEmployee.AddAsync(employeeRequest);
            return Ok(response);
        }

        /// <summary>
        /// This endpoint update a employee by Id.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="employeeRequest"></param>
        /// <returns></returns>
        [HttpPut("update-employee/{employeeId}")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(EmployeeResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId, EmployeeRequestDto employeeRequest)
        {
            var result = await _serviceEmployee.UpdateEmployee(employeeId, employeeRequest);
            return Ok(result);

        }

        /// <summary>
        /// This endpoint update a employee by Id.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="employeeRequest"></param>
        /// <returns></returns>
        [HttpPatch("update-fields-employee/{employeeId}")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(EmployeeResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateEmployeeField(Guid employeeId, EmployeeRequestUpdateFieldDto employeeRequest) 
        {
            var result = await _serviceEmployee.UpdateEmployeeField(employeeId, employeeRequest);
            return Ok(result);

        }
        /// <summary>
        /// This endpoint delete a employee by Id.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
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
