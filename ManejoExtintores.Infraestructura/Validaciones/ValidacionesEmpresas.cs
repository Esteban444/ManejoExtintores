using FluentValidation;
using ManejoExtintores.Core.DTOs;

namespace ManejoExtintores.Infraestructura.Validaciones 
{
    public class ValidacionesEmpresas : AbstractValidator<EmpresaBase>
    {
        public ValidacionesEmpresas()
        {
            RuleFor(empresa => empresa.Nombre)
                .NotEmpty()
                .WithMessage("El campo nombre no puede ir vacio");

            RuleFor(empresa => empresa.Direccion)
                .NotEmpty()
                .WithMessage("El campo direccion no puede ir vacia");

            RuleFor(empresa => empresa.Email)
                .NotEmpty()
                .WithMessage("El campo email no puede ir vacio");
        }
    }
}
