using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos   
{
    public class DetalleServicio
    {
        public int IdDetalleServ { get; set; }
        public int? IdServicios { get; set; }
        public string Descripcion { get; set; }
        public string TipoExtintor { get; set; }
        public int? PesoXlibras { get; set; }
        public decimal? Valor { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Total { get; set; }

        public  Servicio Servicios { get; set; } 
        public  ICollection<PesoExtintor> PesoExtintors { get; set; }
        public  ICollection<Precio> Precios { get; set; }
        public  ICollection<TipoExtintor> TipoExtintors { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}
