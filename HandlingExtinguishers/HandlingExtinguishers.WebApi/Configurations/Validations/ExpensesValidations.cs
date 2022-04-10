﻿using FluentValidation;
using HandlingExtinguishers.DTO.Request.Expenses;

namespace HandlingExtinguishers.WebApi.Configurations.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public class ExpensesValidations: AbstractValidator<ExpensesRequestDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public ExpensesValidations()
        {
            RuleFor(exp => exp.Description)
                .NotEmpty()
                .WithMessage("The description field cannot be empty.");

            RuleFor(exp => exp.Date)
                .NotEmpty()
                .WithMessage("The date field cannot be empty.");

            RuleFor(exp => exp.Quantity)
               .NotEmpty()
               .WithMessage("The quantity field cannot be empty.");

            RuleFor(exp => exp.Total)
               .NotEmpty()
               .WithMessage("The total field cannot be empty.");
        }
    }
}
