using FluentValidation;
using HandlingExtinguishers.DTO.Request.Companies;

namespace HandlingExtinguishers.WebApi.Configurations.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public class CompanyValidations: AbstractValidator<CompanyRequestDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public CompanyValidations() 
        {
            RuleFor(com => com.Name)
                .NotEmpty()
                .WithMessage("The name field cannot be empty.");

            RuleFor(com => com.Phone)
                .NotEmpty()
                .WithMessage("The phone field cannot be empty.");

            RuleFor(com => com.Email)
               .NotEmpty()
               .WithMessage("The email field cannot be empty.");

            RuleFor(com => com.Address)
               .NotEmpty()
               .WithMessage("The address field cannot be empty.");
        }
    }
}
