
namespace ManejoExtintores.Core.DTOs 
{
    public class DetalleServicioBase 
    {
        public int? IdServicios { get; set; }  
        public string Descripcion { get; set; }
        public int? IdTipoExtintor { get; set; }
        public int? IdPesoExtintor { get; set; } 
        public decimal? Valor { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Total { get; set; }
    }
}
