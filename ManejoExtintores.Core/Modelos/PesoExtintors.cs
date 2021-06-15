using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos   
{
    public class PesoExtintors
    {
        public int IdPesoExtintor { get; set; }
        public int? IdDetalleServ { get; set; } = null;
        public int? PesoXlibras { get; set; }

        public DetalleServicios DetalleServicio { get; set; }  
        public ICollection<Productos> Productos { get; set; }
    }
}
