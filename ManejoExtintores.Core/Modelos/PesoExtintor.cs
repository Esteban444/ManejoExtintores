using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.Modelos   
{
    public class PesoExtintor
    {
        public int IdPesoExtintor { get; set; }
        public int? IdDetalleServ { get; set; } = null;
        public int? PesoXlibras { get; set; }

        public virtual DetalleServicio DetalleServ { get; set; } 
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
