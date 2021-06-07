using FluentValidation;
using ManejoExtintores.Core.DTOs;

namespace ManejoExtintores.Infraestructura.Validaciones
{
    public class ValidacionPesoExtintor: AbstractValidator<PesoExtintorBase>
    {
        public ValidacionPesoExtintor()
        {
            RuleFor(p => p.PesoXlibras).NotEmpty().WithMessage("El campo pesoXlibras no puede ir vacio");
        }
    }
}
