using System.Collections.Generic;


namespace ManejoExtintores.Core.DTOs.Responce
{
    public class RespuestaRegistro
    {
        public bool RegistroExitoso { get; set; } 
        public IEnumerable<string> Errors { get; set; }
    }
}
