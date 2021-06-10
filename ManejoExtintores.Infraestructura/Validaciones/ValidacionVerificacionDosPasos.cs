using FluentValidation;
using ManejoExtintores.Core.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoExtintores.Infraestructura.Validaciones
{
    class ValidacionVerificacionDosPasos: AbstractValidator<VerificacionDosPasosDTO>
    {
        public ValidacionVerificacionDosPasos()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("El ampo Email no puede ir vacío");
            RuleFor(x => x.Provider).NotEmpty().WithMessage("El ampo Provider no puede ir vacío");
            RuleFor(x => x.Token).NotEmpty().WithMessage("El ampo Token no puede ir vacío");
        }
    }
}
