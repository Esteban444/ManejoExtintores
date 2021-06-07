using FluentValidation;
using ManejoExtintores.Core.DTOs;

namespace ManejoExtintores.Infraestructura.Validaciones 
{
    public class ValidacionInventario: AbstractValidator<InventarioBase>
    {
        public ValidacionInventario()
        {
            RuleFor(i => i.IdProductos).GreaterThan(0)
               .WithMessage("El campo idproductos no puede ir vacio, y el producto debe existir en la tabla Productos de la base de datos");

            RuleFor(i => i.Descripcion)
                .NotEmpty()
            .WithMessage("El campo descripcion no puede ir vacio");

            RuleFor(i => i.Fecha)
                .NotEmpty()
            .WithMessage("El campo fecha no puede ir vacio");

            RuleFor(i => i.Cantidad)
                .NotEmpty()
            .WithMessage("El campo cantidad no puede ir vacia");

            RuleFor(i => i.FechaVencimiento)
                .NotEmpty()
            .WithMessage("El campo fechaVencimiento no puede ir vacia");
        }
    }
}
