using FluentValidation;
using ManejoExtintores.Core.DTOs.Request;

namespace ManejoExtintores.Infraestructura.Validaciones
{
    class ValidacionVerificacionDosPasos: AbstractValidator<VerificacionDosPasosDTO>
    {
        public ValidacionVerificacionDosPasos()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("El campo Email no puede ir vacío");
            RuleFor(x => x.Provider).NotEmpty().WithMessage("El campo Provider no puede ir vacío");
            RuleFor(x => x.Token).NotEmpty().WithMessage("El campo Token no puede ir vacío");
        }
    }
}
