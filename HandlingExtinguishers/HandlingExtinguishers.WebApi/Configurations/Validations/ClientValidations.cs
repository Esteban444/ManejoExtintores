using FluentValidation;
using HandlingExtinguishers.DTO.Request;

namespace HandlingExtinguishers.WebApi.Configurations.Validations
{
    public class ClientValidations: AbstractValidator<ClientRequestDto>
    {
        public ClientValidations()
        {
            
            RuleFor(e => e.FirstName)
                .NotEmpty()
                .WithMessage("The firstname field cannot be empty.");

            RuleFor(e => e.Email)
               .NotEmpty()
               .WithMessage("The email field cannot be empty.");


            RuleFor(e => e.Address)
               .NotEmpty()
               .WithMessage("The address field cannot be empty.");
        }
    }
}
