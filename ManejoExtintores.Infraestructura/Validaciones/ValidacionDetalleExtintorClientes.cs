using FluentValidation;
using ManejoExtintores.Core.DTOs.Request;

namespace ManejoExtintores.Infraestructura.Validaciones
{
    public class ValidacionDetalleExtintorClientes : AbstractValidator<DetalleExtClienteBase>
    {
        public ValidacionDetalleExtintorClientes()
        {
            RuleFor(x => x.IdClientes).GreaterThan(0).WithMessage("El campo cliente debe existir en la tabla clientes de la base de datos.");
            RuleFor(x => x.IdServicio).GreaterThan(0).WithMessage("El campo servicio debe existir en la tabla servicios de la base de datos.");
            RuleFor(x => x.TipoExtintor).NotEmpty().WithMessage("El campo tipo extintor no puede ir vacío.");
            RuleFor(x => x.FechaServicio).NotEmpty().WithMessage("El campo fecha servicio no puede ir vacío.");
            RuleFor(x => x.FechaMantenimiento).NotEmpty().WithMessage("El campo fecha mantenimiento no puede ir vacío.");
            RuleFor(x => x.FechaVencimiento).NotEmpty().WithMessage("El campo fecha Vencimiento no puede ir vacío.");
        }
    }
}
