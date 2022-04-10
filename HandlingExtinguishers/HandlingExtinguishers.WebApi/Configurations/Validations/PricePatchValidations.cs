using FluentValidation;
using HandlingExtinguishers.DTO.Request.Prices;

namespace HandlingExtinguishers.WebApi.Configurations.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public class PricePatchValidations: AbstractValidator<PriceRequestUpdateFieldDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public PricePatchValidations() 
        {
            RuleFor(p => p.Iva).NotEmpty()
                .When(d => d.Price != null)
                .WithMessage("If you are going to modify the price you must also send the vat.");

        }
    }
}
