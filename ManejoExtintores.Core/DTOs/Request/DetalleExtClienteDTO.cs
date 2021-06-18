
namespace ManejoExtintores.Core.DTOs.Request
{
    public class DetalleExtClienteDTO: DetalleExtClienteBase
    {
        public int IdDetalleCliente { get; set; }

        public ClienteDTO Cliente { get; set; } 
        public ServicioDTO Servicio { get; set; }
    }
}
