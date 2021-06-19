using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos   
{
    public class PesoExtintors
    {
        public int IdPesoExtintor { get; set; }
        public int? PesoXlibras { get; set; }

        public ICollection<DetalleServicios> DetalleServicios { get; set; }
        public ICollection<Inventarios> Inventarios { get; set; }
        public ICollection<Productos> Productos { get; set; }
    }
}
