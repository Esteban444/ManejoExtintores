using FluentValidation;
using ManejoExtintores.Core.DTOs;

namespace ManejoExtintores.Infraestructura.Validaciones 
{
    public class ValidacionClientes: AbstractValidator<ClientesBase>
    {
        public ValidacionClientes()
        {
            RuleFor(c => c.Nombre).NotEmpty().WithMessage("El campo nombre no puede ir vacio");
            RuleFor(c => c.Direccion).NotEmpty().WithMessage("El campo direccion no puede ir vacio");
        }
    }
}
