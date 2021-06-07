using FluentValidation;
using ManejoExtintores.Core.DTOs;

namespace ManejoExtintores.Infraestructura.Validaciones
{
    public class ValidacionesPrecios: AbstractValidator<PrecioBase>
    {
        public ValidacionesPrecios()
        {
            RuleFor(precio => precio.IdProductos).GreaterThan(0)
                .WithMessage("El campo id productos no puede ir vacio,El producto debe existir en la tabla productos de la base de datos");
        
         RuleFor(precio => precio.Descripcion)
                .NotEmpty()
            .WithMessage("La descripcion no puede ir vacio");

         RuleFor(precio => precio.Valor)
                .NotEmpty()
            .WithMessage("El Valor no puede ir vacio");
        }
    }
}
