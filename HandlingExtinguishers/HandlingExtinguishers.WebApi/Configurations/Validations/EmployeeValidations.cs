using FluentValidation;
using HandlingExtinguishers.DTO.Request.Employees;

namespace HandlingExtinguishers.WebApi.Configurations.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeValidations: AbstractValidator<EmployeeRequestDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public EmployeeValidations()
        {
            RuleFor(e => e.CompanyId)
                .NotEmpty()
                .WithMessage("The IdCompany field cannot be empty.");

            RuleFor(e => e.FirstName)
                .NotEmpty()
                .WithMessage("The firstname field cannot be empty.");

            RuleFor(e => e.LastName)
                .NotEmpty()
                .WithMessage("The LastName field cannot be empty.");

            RuleFor(e => e.Gender)
               .NotEmpty()
               .WithMessage("The gender field cannot be empty.");

            RuleFor(e => e.Email)
               .NotEmpty()
               .WithMessage("The email field cannot be empty.");

            RuleFor(e => e.MobilePhone)
               .NotEmpty()
               .WithMessage("The mobilePhone field cannot be empty.");

            RuleFor(e => e.Address)
               .NotEmpty()
               .WithMessage("The address field cannot be empty.");
        }
    }
}
