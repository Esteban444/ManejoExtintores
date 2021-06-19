using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos   
{
    public class TipoExtintors
    {
        public int IdTipoExtintor { get; set; }
        public string Tipo_Extintor { get; set; }

        public ICollection<DetalleServicios> DetalleServicios { get; set; }
        public ICollection<Inventarios> Inventarios { get; set; }
        public ICollection<Productos> Productos { get; set; }
    }
}
