using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.Modelos   
{
    public class TipoExtintor
    {
        public int IdTipoExtintor { get; set; }
        public int? IdDetalleServ { get; set; } = null;
        public string Tipo_Extintor { get; set; }  

        public virtual DetalleServicio DetalleServ { get; set; } 
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
