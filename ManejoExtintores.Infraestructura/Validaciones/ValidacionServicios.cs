using FluentValidation;
using ManejoExtintores.Core.DTOs;

namespace ManejoExtintores.Infraestructura.Validaciones
{
    class ValidacionServicios: AbstractValidator<ServicioBase>
    {
        public ValidacionServicios()
        {
            RuleFor(s => s.IdClientes).GreaterThan(0)
                .WithMessage("El campo cliente debe existir en la tabla clientes de la base de datos");

            RuleFor(s => s.IdEmpleados).GreaterThan(0)
                .WithMessage("El empleado debe existir en la tabla empleados de la base de datos");

            RuleFor(s => s.FechaServicio).NotEmpty().WithMessage("El campo fehaServicio no puede ir vacio");
            RuleFor(s => s.Estado).NotEmpty().WithMessage("El campo estado no puede ir vacio");
        }
    }
}
