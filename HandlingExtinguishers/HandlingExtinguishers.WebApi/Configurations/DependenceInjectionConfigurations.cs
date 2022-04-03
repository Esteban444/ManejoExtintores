using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Services;
using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.WebApi.Configurations.Validations;

namespace HandlingExtinguishers.WebApi.Configurations
{
    public static class DependenceInjectionConfigurations
    {
        public static IServiceCollection AddDependenceInjectionConfiguration(this IServiceCollection services)
        {
            #region Repositories
            services.AddScoped<IRepositoryCompanies, CompaniesRepository>();
            services.AddScoped<IRepositoryExpenses, ExpensesRepository>();
            services.AddScoped<IRepositoryEmployees, EmployeeRepository>();
            #endregion End Repositories

            #region Services
            services.AddScoped<IServiceCompanies, ServiceCompanies>();
            services.AddScoped<IServiceExpenses, ServiceExpenses>();
            services.AddScoped<IServiceEmployees, ServiceEmployees>();
            #endregion End Services

            #region Validators
            services.AddScoped<IValidator<CompanyRequestDto>, CompanyValidations>(); 
            services.AddScoped<IValidator<ExpensesRequestDto>, ExpensesValidations>();
            services.AddScoped<IValidator<EmployeeRequestDto>, EmployeeValidations>();  
            #endregion Validators


            return services;
        }
    }
}
