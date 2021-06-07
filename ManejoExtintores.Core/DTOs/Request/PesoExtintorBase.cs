using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.DTOs 
{
    public class PesoExtintorBase
    {
        //public int? IdDetalleServ { get; set; } = null;
        [Required (ErrorMessage = "El peso no puede ir vacio")]
        public int? PesoXlibras { get; set; }
    }
}
