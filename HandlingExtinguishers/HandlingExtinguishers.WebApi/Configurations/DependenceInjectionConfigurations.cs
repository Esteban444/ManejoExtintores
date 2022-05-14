using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Services;
using HandlingExtinguishers.DTO.Request.Clients;
using HandlingExtinguishers.DTO.Request.Companies;
using HandlingExtinguishers.DTO.Request.Employees;
using HandlingExtinguishers.DTO.Request.Expenses;
using HandlingExtinguishers.DTO.Request.Inventories;
using HandlingExtinguishers.DTO.Request.Prices;
using HandlingExtinguishers.DTO.Request.Products;
using HandlingExtinguishers.DTO.Request.TypeExtinguisher;
using HandlingExtinguishers.DTO.Request.WeightExtinguisher;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.WebApi.Configurations.Validations;

namespace HandlingExtinguishers.WebApi.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependenceInjectionConfigurations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDependenceInjectionConfiguration(this IServiceCollection services)
        {
            #region Repositories
            services.AddScoped<IRepositoryClients, ClientsRepository>();
            services.AddScoped<IRepositoryCompanies, CompaniesRepository>();
            services.AddScoped<IRepositoryExpenses, ExpensesRepository>();
            services.AddScoped<IRepositoryEmployees, EmployeesRepository>();
            services.AddScoped<IRepositoryInventory, InventoryRepository>();
            services.AddScoped<IRepositoryPrice, PricesRepository>();
            services.AddScoped<IRepositoryProducts, ProductsRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IRepositoryTypeExtinguisher, TypeExtinguishersRepository>();
            services.AddScoped<IRepositoryWeightExtinguisher, WeightExtinguisherRepository>(); 
            #endregion End Repositories

            #region Services
            services.AddScoped<IAuthService, AuthService>(); 
            services.AddScoped<IServiceClients, ServiceClients>(); 
            services.AddScoped<IServiceCompanies, ServiceCompanies>();
            services.AddScoped<IServiceExpenses, ServiceExpenses>();
            services.AddScoped<IServiceEmployees, ServiceEmployees>();
            services.AddScoped<IInventoryService, ServiceInventory>();
            services.AddScoped<IServicePrices, ServicePrices>();
            services.AddScoped<IProductsService, ServiceProducts>();
            services.AddScoped<IServiceTypeExtinguishers, ServiceTypeExtinguishers>();
            services.AddScoped<IServiceWeightExtinguishers, ServiceWeightExtinguishers>();
            #endregion End Services

            #region Validators
            services.AddScoped<IValidator<ClientRequestDto>, ClientValidations>(); 
            services.AddScoped<IValidator<CompanyRequestDto>, CompanyValidations>(); 
            services.AddScoped<IValidator<ExpensesRequestDto>, ExpensesValidations>();
            services.AddScoped<IValidator<EmployeeRequestDto>, EmployeeValidations>();  
            services.AddScoped<IValidator<InventoryRequestDto>, InventoryValidations>();  
            services.AddScoped<IValidator<PriceRequestDto>, PriceValidations>();  
            services.AddScoped<IValidator<PriceRequestUpdateFieldDto>, PricePatchValidations>();  
            services.AddScoped<IValidator<ProductsRequestDto>, ProductsValidations>();  
            services.AddScoped<IValidator<TypeExtinguisherRequestDto>, TypeExtinguisherValidations>();  
            services.AddScoped<IValidator<WeightExtinguisherRequestDto>, WeightExtinguisherValidations>();  
            #endregion Validators


            return services;
        }
    }
}
