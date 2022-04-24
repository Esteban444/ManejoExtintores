using FluentValidation;
using HandlingExtinguishers.DTO.Request.WeightExtinguisher;

namespace HandlingExtinguishers.WebApi.Configurations.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public class WeightExtinguisherValidations : AbstractValidator<WeightExtinguisherRequestDto>
    {
        /// <summary>
        /// Methodo constructor.
        /// </summary>
        public WeightExtinguisherValidations()  
        {

            RuleFor(e => e.WeightPound)
                .NotEmpty()
                .WithMessage("The weight pound field cannot be empty.");

        }
    }
}
