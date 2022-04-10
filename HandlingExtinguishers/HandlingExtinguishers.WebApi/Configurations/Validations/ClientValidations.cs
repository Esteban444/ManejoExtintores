using FluentValidation;
using HandlingExtinguishers.DTO.Request.Clients;

namespace HandlingExtinguishers.WebApi.Configurations.Validations
{
    /// <summary>
    /// Class to validate cliente request.
    /// </summary>
    public class ClientValidations: AbstractValidator<ClientRequestDto>
    {
        /// <summary>
        /// Methodo constructor.
        /// </summary>
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
