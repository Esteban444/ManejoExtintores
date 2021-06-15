using System;

namespace ManejoExtintores.Core.Modelos   
{
    public class Gastos 
    {
        public int IdGastos { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Total { get; set; }
    }
}
