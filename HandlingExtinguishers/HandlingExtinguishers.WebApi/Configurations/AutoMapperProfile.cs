using AutoMapper;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;

namespace  HandlingExtinguishers.WebApi.Configurations
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Company, CompanyResponseDto>().ReverseMap();
            CreateMap<CompanyRequestDto, CompanyResponseDto>().ReverseMap();
            CreateMap<Company, CompanyRequestDto>().ReverseMap();

            CreateMap<Expense, ExpenseResponseDto>().ReverseMap();
            CreateMap<ExpensesRequestDto, ExpenseResponseDto>().ReverseMap();
            CreateMap<Expense, ExpensesRequestDto>().ReverseMap();

            CreateMap<Employee, EmployeeResponseDto>().ReverseMap();
            CreateMap<EmployeeRequestDto, EmployeeResponseDto>().ReverseMap();
            CreateMap<Employee, EmployeeRequestDto>().ReverseMap();
        }
    }
}
