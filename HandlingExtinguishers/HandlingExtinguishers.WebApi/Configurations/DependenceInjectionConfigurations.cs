﻿using FluentValidation;
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
               services.AddTransient<IRepositoryExpenses, ExpensesRepository>();
            #endregion End Repositories

            #region Services
            services.AddTransient<IServiceExpenses, ServiceExpenses>();
            #endregion End Services

            #region Validators
            services.AddScoped<IValidator<ExpensesRequestDto>, ExpensesValidations>();
            #endregion Validators


            return services;
        }
    }
}
