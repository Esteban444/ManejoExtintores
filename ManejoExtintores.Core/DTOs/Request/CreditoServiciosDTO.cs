
namespace ManejoExtintores.Core.DTOs.Request
{
    public class CreditoServiciosDTO: CreditoServicioBase
    {
        public int IdCreditos { get; set; }
        public ServicioDTO Servicio { get; set; }   
    }
}
