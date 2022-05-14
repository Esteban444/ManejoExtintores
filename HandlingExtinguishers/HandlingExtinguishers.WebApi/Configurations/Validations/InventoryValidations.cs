using FluentValidation;
using HandlingExtinguishers.DTO.Request.Inventories;

namespace HandlingExtinguishers.WebApi.Configurations.Validations
{
    /// <summary>
    /// Class to validate inventory request.
    /// </summary>
    public class InventoryValidations : AbstractValidator<InventoryRequestDto>
    {
        /// <summary>
        /// Methodo constructor.
        /// </summary>
        public InventoryValidations() 
        {

            RuleFor(e => e.Amount)
                .NotEmpty()
                .WithMessage("The amount field cannot be empty.");

            RuleFor(e => e.ExpirationDate)
               .NotEmpty()
               .WithMessage("The expiration date field cannot be empty.");
        }
    }

}
