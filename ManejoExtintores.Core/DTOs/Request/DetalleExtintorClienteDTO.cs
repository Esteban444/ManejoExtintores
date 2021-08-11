
namespace ManejoExtintores.Core.DTOs.Request
{
    public class DetalleExtintorClienteDTO: DetalleExtintorClienteBase
    {
        public int IdDetalleCliente { get; set; }

        public ClienteDTO Cliente { get; set; } 
    }
}
