using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request.Employees;
using HandlingExtinguishers.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingExtinguishers.Core.Services
{
    public class ServiceEmployees : IServiceEmployees
    {
        private readonly IRepositoryEmployees _repositoryEmployees;
        private readonly IMapper _mapper;

        public ServiceEmployees(IRepositoryEmployees employees, IMapper mapper)
        {
            _repositoryEmployees = employees;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeResponseDto>> GetAllEmployees(EmployeeFilter filter)
        {
            var employees = _repositoryEmployees.FindBy(x => x.Active);

            if (!String.IsNullOrEmpty(filter.FirstName) || !String.IsNullOrEmpty(filter.LastName))
            {
                employees = employees.Where(x => x.FirstName!.Contains(filter.FirstName!) ||  x.LastName!.Contains(filter.LastName!));
            }

            if (filter.BirthDate != null)
            {
                employees = employees.Where(x => x.BirthDate == filter.BirthDate);
            }
            var response = await employees.OrderBy(x => x.FirstName).ToListAsync();
            var employeeslist = _mapper.Map<IEnumerable<EmployeeResponseDto>>(response);
            return employeeslist;
        }

        public async Task<EmployeeResponseDto> GetEmployeeBy(Guid employeeId)
        {
            var employeeBd = await _repositoryEmployees.FindBy(c => c.Id == employeeId).FirstOrDefaultAsync();
            if (employeeBd == null) throw new GlobalException("The employee record does not exist in the database.", HttpStatusCode.NotFound);

            return _mapper.Map<EmployeeResponseDto>(employeeBd);
        }

        public async Task<EmployeeResponseDto> AddAsync(EmployeeRequestDto employeeRequest)
        {
            if (employeeRequest.Active == null) { employeeRequest.Active = true; } 
            var employee = _mapper.Map<EmployeeTable>(employeeRequest);
            await _repositoryEmployees.Add(employee);
            var newemployee = _mapper.Map<EmployeeResponseDto>(employee);
            return newemployee;
        }

        public async Task<EmployeeResponseDto> UpdateEmployee(Guid employeeId, EmployeeRequestDto employeeRequestUpdate)
        {
            if (employeeRequestUpdate.Active == null) { employeeRequestUpdate.Active = true; }
            var employeeBd = await _repositoryEmployees.FindBy(c => c.Id == employeeId).FirstOrDefaultAsync();
            if (employeeBd == null) throw new GlobalException("The employee record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            _mapper.Map(employeeRequestUpdate, employeeBd);

            await _repositoryEmployees.Update(employeeBd);
            var response = _mapper.Map<EmployeeResponseDto>(employeeBd);
            return response;
        }

        public async Task<EmployeeResponseDto> UpdateEmployeeField(Guid employeeId, EmployeeRequestUpdateFieldDto employeeRequestUpdateField) 
        {
            var employeeBd = await _repositoryEmployees.FindBy(x => x.Id == employeeId).FirstOrDefaultAsync();
            if (employeeBd == null) throw new GlobalException("The employee record you are trying to update does not exist in the database.", HttpStatusCode.NotFound);

            var properties = new UpdateMapperProperties<EmployeeTable, EmployeeRequestUpdateFieldDto>();
            var updateEmployee = await properties.MapperUpdate(employeeBd!, employeeRequestUpdateField);
            await _repositoryEmployees.Update(updateEmployee);
            var response = _mapper.Map<EmployeeResponseDto>(updateEmployee);
            return response;
        }

        public async Task<EmployeeResponseDto> DeleteEmployee(Guid employeeId)
        {
            var employeeBd = await _repositoryEmployees.FindBy(c => c.Id == employeeId).FirstOrDefaultAsync();
            if (employeeBd == null) throw new GlobalException("The employee record you are trying to delete does not exist in the database.", HttpStatusCode.NotFound);
            await _repositoryEmployees.Delete(employeeBd);
            var employeeDeleted = _mapper.Map<EmployeeResponseDto>(employeeBd);
            return employeeDeleted;
        }
    }
}
