using FluentValidation;
using ManejoExtintores.Core.DTOs;

namespace ManejoExtintores.Infraestructura.Validaciones
{
    public class ValidacionTipoExtintor: AbstractValidator<TipoExtintorBase>
    {
        public ValidacionTipoExtintor()
        {
            RuleFor(t => t.Tipo_Extintor).NotEmpty().WithMessage("El campo tipoExtintor no puede ir vacio");
        }
    }
}
