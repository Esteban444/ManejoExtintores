using AutoMapper;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Request.Clients;
using HandlingExtinguishers.DTO.Request.Companies;
using HandlingExtinguishers.DTO.Request.Employees;
using HandlingExtinguishers.DTO.Request.Expenses;
using HandlingExtinguishers.DTO.Request.Prices;
using HandlingExtinguishers.DTO.Response;

namespace  HandlingExtinguishers.WebApi.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperProfile: Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, RegisterUserRequestDto>().ReverseMap();

            CreateMap<ClientTable, ClientResponseDto>().ReverseMap();
            CreateMap<ClientRequestDto, ClientResponseDto>().ReverseMap();
            CreateMap<ClientTable, ClientRequestDto>().ReverseMap();

            CreateMap<CompanyTable, CompanyResponseDto>().ReverseMap();
            CreateMap<CompanyRequestDto, CompanyResponseDto>().ReverseMap();
            CreateMap<CompanyTable, CompanyRequestDto>().ReverseMap();

            CreateMap<ExpenseTable, ExpenseResponseDto>().ReverseMap();
            CreateMap<ExpensesRequestDto, ExpenseResponseDto>().ReverseMap();
            CreateMap<ExpenseTable, ExpensesRequestDto>().ReverseMap();

            CreateMap<EmployeeTable, EmployeeResponseDto>().ReverseMap();
            CreateMap<EmployeeRequestDto, EmployeeResponseDto>().ReverseMap();
            CreateMap<EmployeeTable, EmployeeRequestDto>().ReverseMap();

            CreateMap<PriceTable, PriceResponseDto>().ReverseMap();
            CreateMap<PriceRequestDto, PriceResponseDto>().ReverseMap();
            CreateMap<PriceTable, PriceRequestDto>().ReverseMap();
        }
    }
}
