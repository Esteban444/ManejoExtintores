using AutoMapper;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Request.Clients;
using HandlingExtinguishers.DTO.Request.Companies;
using HandlingExtinguishers.DTO.Request.Employees;
using HandlingExtinguishers.DTO.Request.Expenses;
using HandlingExtinguishers.DTO.Request.Inventories;
using HandlingExtinguishers.DTO.Request.Prices;
using HandlingExtinguishers.DTO.Request.Products;
using HandlingExtinguishers.DTO.Request.Services;
using HandlingExtinguishers.DTO.Request.TypeExtinguisher;
using HandlingExtinguishers.DTO.Request.WeightExtinguisher;
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

            CreateMap<InventoryTable, InventoryResponseDto>().ReverseMap();
                //.ForMember(x => x.TypeExtinguisher, z => z.MapFrom(y => y.Product!.TypeExtinguisher))
                //.ForMember(x => x.WeightExtinguisher, e => e.MapFrom(w => w.Product!.WeightExtinguisher)).ReverseMap();
            CreateMap<InventoryRequestDto, InventoryResponseDto>().ReverseMap();
            CreateMap<InventoryTable, InventoryRequestDto>().ReverseMap();

            CreateMap<PriceTable, PriceResponseDto>().ReverseMap();
            CreateMap<PriceRequestDto, PriceResponseDto>().ReverseMap();
            CreateMap<PriceTable, PriceRequestDto>().ReverseMap();

            CreateMap<ProductTable, ProductsResponseDto>().ReverseMap();
            CreateMap<ProductsRequestDto, ProductsResponseDto>().ReverseMap();
            CreateMap<ProductTable, ProductsRequestDto>().ReverseMap();

            CreateMap<ServiceTable, ServiceResponseDto>().ReverseMap();
            CreateMap<ServiceRequestDto, ServiceResponseDto>().ReverseMap();
            CreateMap<ServiceTable, ServiceRequestDto>().ReverseMap();

            CreateMap<TypeExtinguisherTable, TypeExtinguisherResponseDto>().ReverseMap();
            CreateMap<TypeExtinguisherRequestDto, TypeExtinguisherResponseDto>().ReverseMap();
            CreateMap<TypeExtinguisherTable, TypeExtinguisherRequestDto>().ReverseMap();

            CreateMap<WeightExtinguisherTable, WeightExtinguisherResponseDto>().ReverseMap(); 
            CreateMap<WeightExtinguisherRequestDto, WeightExtinguisherResponseDto>().ReverseMap();
            CreateMap<WeightExtinguisherTable, WeightExtinguisherRequestDto>().ReverseMap();
        }
    }
}
