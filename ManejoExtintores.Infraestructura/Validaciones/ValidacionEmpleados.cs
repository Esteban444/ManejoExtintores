using FluentValidation;
using ManejoExtintores.Core.DTOs;

namespace ManejoExtintores.Infraestructura.Validaciones 
{
    public class ValidacionEmpleados : AbstractValidator<EmpleadoBase>
    {
        public ValidacionEmpleados()
        {
            RuleFor(empleado => empleado.IdEmpresa).GreaterThan(0)
                .WithMessage("El campo idempresa no puede ir vacio, y la empresa debe existir en la tabla empresas de la base de datos");

            RuleFor(empleado => empleado.Nombre)
                .NotEmpty()
            .WithMessage("El campo nombre no puede ir vacio");

            RuleFor(empleado => empleado.Apellido)
                .NotEmpty()
            .WithMessage("El campo Apellido no puede ir vacio");

            RuleFor(empleado => empleado.Telefono)
                .NotEmpty()
            .WithMessage("El campo telefono no puede ir vacia");

            RuleFor(empleado => empleado.Email)
                .NotEmpty()
                .WithMessage("El campo email no puede ir vacio");
        }
    }
}
