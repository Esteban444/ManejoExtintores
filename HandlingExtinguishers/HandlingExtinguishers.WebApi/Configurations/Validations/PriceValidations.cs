using FluentValidation;
using HandlingExtinguishers.DTO.Request.Prices;

namespace HandlingExtinguishers.WebApi.Configurations.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public class PriceValidations: AbstractValidator<PriceRequestDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public PriceValidations()
        {
            
            RuleFor(p => p.Price )
                .NotEmpty()
                .WithMessage("The price field cannot be empty.");

            RuleFor(p => p.Iva)
                .NotEmpty()
                .WithMessage("The iva field cannot be empty.");

        }
    }
}
