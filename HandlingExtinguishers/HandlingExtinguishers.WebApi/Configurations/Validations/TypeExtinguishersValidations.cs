using FluentValidation;
using HandlingExtinguishers.DTO.Request.TypeExtinguisher;

namespace HandlingExtinguishers.WebApi.Configurations.Validations
{
    /// <summary>
    /// Class to validate cliente request.
    /// </summary>
    public class TypeExtinguisherValidations: AbstractValidator<TypeExtinguisherRequestDto>
    {
        /// <summary>
        /// Methodo constructor.
        /// </summary>
        public TypeExtinguisherValidations()
        {
            
            RuleFor(e => e.TypeExtinguisher)
                .NotEmpty()
                .WithMessage("The type field cannot be empty.");

        }
    }
}
