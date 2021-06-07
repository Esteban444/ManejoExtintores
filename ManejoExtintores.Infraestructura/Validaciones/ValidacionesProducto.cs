using FluentValidation;
using ManejoExtintores.Core.DTOs;


namespace ManejoExtintores.Infraestructura.Validaciones 
{
    class ValidacionesProducto: AbstractValidator<ProductoBase>
    {
        public ValidacionesProducto()
        {
            RuleFor(p => p.IdPesoExtintor).GreaterThan(0)
                .WithMessage("El campo idPesoExtintor debe existir en la tabla PesoExtintores de la base de datos");

            RuleFor(p => p.IdTipoExtintor).GreaterThan(0)
                .WithMessage("El campo idTipoExtintor debe existir en la tabla TipoExtintores de la base de datos");

            RuleFor(p => p.TipoProducto)
                    .NotEmpty()
                .WithMessage("El campo tipo de producto no puede ir vacio");

            

        }
    }
}
