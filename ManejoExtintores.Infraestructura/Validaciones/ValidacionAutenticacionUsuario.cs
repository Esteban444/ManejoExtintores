using FluentValidation;
using ManejoExtintores.Core.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoExtintores.Infraestructura.Validaciones
{
    public class ValidacionAutenticacionUsuario:AbstractValidator<AutenticacionUsuarioDTO>
    {
        public ValidacionAutenticacionUsuario()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("El campo Email no puede ir vacío");
            RuleFor(x => x.Password).NotEmpty().WithMessage("El campo Password no puede ir vacío");
        }
    }
}
