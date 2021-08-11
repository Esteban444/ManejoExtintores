using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos    
{
    public class Clientes 
    {
        public int IdCliente { get; set; }
        public decimal? DocCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Nit { get; set; }

        public ICollection<DetalleExtintorClientes> DetalleExtClientes { get; set; }
        public ICollection<Servicio> Servicios { get; set; }
    }
}
