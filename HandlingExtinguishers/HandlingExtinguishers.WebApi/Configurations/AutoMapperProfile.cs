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
            CreateMap<Companies, CompanyResponseDto>().ReverseMap();
            CreateMap<CompanyRequestDto, CompanyResponseDto>().ReverseMap();
            CreateMap<Companies, CompanyRequestDto>().ReverseMap();

            CreateMap<Expenses, ExpenseResponseDto>().ReverseMap();
            CreateMap<ExpensesRequestDto, ExpenseResponseDto>().ReverseMap();
            CreateMap<Expenses, ExpensesRequestDto>().ReverseMap();
        }
    }
}
