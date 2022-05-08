using FluentValidation;
using HandlingExtinguishers.DTO.Request.Products;

namespace HandlingExtinguishers.WebApi.Configurations.Validations
{
    /// <summary>
    /// Class to validate products request.
    /// </summary>
    public class ProductsValidations : AbstractValidator<ProductsRequestDto>
    {
        /// <summary>
        /// Methodo constructor.
        /// </summary>
        public ProductsValidations()
        {

            RuleFor(e => e.TypeProduct)
                .NotEmpty()
                .WithMessage("The tipe product field cannot be empty.");


        }

    }
}
