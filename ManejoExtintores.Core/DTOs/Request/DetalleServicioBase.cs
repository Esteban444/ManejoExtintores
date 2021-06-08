using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.DTOs 
{
    public class DetalleServicioBase 
    {
        public int? IdServicio { get; set; } 
        public string Descripcion { get; set; }
        public string TipoExtintor { get; set; }
        public int? PesoXlibras { get; set; }
        public decimal? Valor { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Total { get; set; }
    }
}
