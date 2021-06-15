using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos   
{
    public class TipoExtintors
    {
        public int IdTipoExtintor { get; set; }
        public int? IdDetalleServ { get; set; } = null;
        public string Tipo_Extintor { get; set; }  

        public DetalleServicios DetalleServicio { get; set; }  
        public ICollection<Productos> Productos { get; set; }
    }
}
