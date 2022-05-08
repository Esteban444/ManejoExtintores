using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Request.Employees;
using HandlingExtinguishers.DTO.Response;


namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceEmployees
    {
        Task<IEnumerable<EmployeeResponseDto>> GetAllEmployees(EmployeeFilterDto filter);
        Task<EmployeeResponseDto> GetEmployeeBy(Guid employeeId); 
        Task<EmployeeResponseDto> AddAsync(EmployeeRequestDto employeeRequest);
        Task<EmployeeResponseDto> UpdateEmployee(Guid employeeId, EmployeeRequestDto employeeRequest);
        Task<EmployeeResponseDto> UpdateEmployeeField(Guid employeeId, EmployeeRequestUpdateFieldDto employeeRequestUpdateField);
        Task<EmployeeResponseDto> DeleteEmployee(Guid employeeId); 
    }
}
